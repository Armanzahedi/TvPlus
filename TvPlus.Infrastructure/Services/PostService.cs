using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using TvPlus.Core.Models;
using TvPlus.DataAccess;
using TvPlus.DataAccess.Repositories;
using TvPlus.Infrastructure.Dtos.Post;
using TvPlus.Infrastructure.ViewModels;
using TvPlus.Services.Membership;
using TvPlus.Utility;
using TvPlus.Utility.Enums;

namespace TvPlus.Infrastructure.Services
{
    public interface IPostService : IPostRepository
    {
        Post Save(Post entity);
        //new IEnumerable<PostDto> GetListPaged(int pageNumber, int itemsPerPage);
        EditPostViewModel GetPostForEdit(int id);
        string GetPostTags(int id);
        string GetPostPeople(int id);
        Post SavePost(EditPostViewModel post);
        List<Tag> SavePostTags(Post post, List<string> tags);
        List<People> SavePostPeople(Post post, List<string> people);
        Task<List<PostViewModel>> GetSpecialPostsAsync();
        Task<List<PostViewModel>> GetTrendTvsAsync();
        Task<List<PostViewModel>> GetRecentVideosAsync(int count);
        Task<List<PostViewModel>> GetMostViewedPostAsync();
        Task<List<PostViewModel>> GetHottestPostAsync();
        Task<List<PostViewModel>> GetControversialPostAsync();
        Task<List<PostViewModel>> GetTopTensAsync();
        List<Category> GetPostCategories(int id);
        PostDetailsViewModel GetPostDetail(int id);
    }

    public class PostService : PostRepository, IPostService
    {
        private readonly IMapper _mapper;
        private readonly ITagService _tagService;
        private readonly IPeopleService _peopleService;
        private readonly IVideoService _videoService;
        private readonly IImageService _imageService;
        private readonly IMembershipManagementBaseService _membershipManagementService;
        private readonly ICenterService _centerService;
        private readonly MyDbContext _context;

        public PostService(
            IMapper mapper,
            IMembershipManagementBaseService membershipManagementService,
            ITagService tagService,
            IPeopleService peopleService,
            MyDbContext context, IVideoService videoService, IImageService imageService, ICenterService centerService) : base(context)
        {
            _mapper = mapper;
            _context = context;
            _videoService = videoService;
            _imageService = imageService;
            _centerService = centerService;
            _membershipManagementService = membershipManagementService;
            _tagService = tagService;
            _peopleService = peopleService;
        }
        public List<Tag> SavePostTags(Post post, List<string> tags)
        {
            var message = string.Empty;
            var result = new List<Tag>();

            var prevMembers = _membershipManagementService.GetSelfMemberships(post, RelationTypes.PostTags, false);
            foreach (var item in prevMembers)
            {
                _membershipManagementService.DeleteMembership(item, null, out message);
            }
            tags.ForEach(item =>
            {
                var tag = _tagService.FindByTitle(item) ?? new Tag() { Title = item };
                if (tag.Id == 0)
                {
                    tag.CenterTypeId = (int)CenterTypes.Tags;
                    tag.UniqueId = Guid.NewGuid();
                    _tagService.Save(tag);
                }

                var MemberId = _membershipManagementService.GetMemberships(post.Id, tag.Id, RelationTypes.PostTags,
                    false, false).FirstOrDefault()?.MemberId;

                _membershipManagementService.RegisterMembership(post, tag, DateTime.Now, null, out message,
                    MemberId, RelationTypes.PostTags, null);
                var tagDto = _mapper.Map<PostTagsDto>(tag);
                result.Add(tag);
            });
            return result;
        }
        public List<People> SavePostPeople(Post post, List<string> people)
        {
            var message = string.Empty;
            var result = new List<People>();
            var prevMembers = _membershipManagementService.GetSelfMemberships(post, RelationTypes.PostPeople, false);
            foreach (var item in prevMembers)
            {
                _membershipManagementService.DeleteMembership(item, null, out message);
            }
            people.ForEach(item =>
            {
                var people = _peopleService.FindByFirstAndLastName(item) ?? new People();
                if (people.Id != 0)
                {
                    var MemberId = _membershipManagementService.GetMemberships(post.Id, people.Id,
                        RelationTypes.PostPeople,
                        false, false).FirstOrDefault()?.MemberId;

                    _membershipManagementService.RegisterMembership(post, people, DateTime.Now, null, out message,
                        MemberId, RelationTypes.PostPeople, null);
                    result.Add(people);
                }

            });
            return result;
        }

        public Image GetPostImage(int postId)
        {
            return _context.Images.FirstOrDefault(i => i.CenterId == postId);
        }

        public Post SavePost(EditPostViewModel model)
        {
            var message = string.Empty;

            var post = _context.Posts.FirstOrDefault(p=>p.Id == model.Id) ?? new Post{ Id = model.Id};

            post.PublishDate = DateTime.Now;
            post.ShortTitle = model.ShortTitle;
            post.Title = model.Title;
            post.Description = model.Description;
            post.Context = model.Context;

            var savedPost = Save(post);

            //save tags
            if (!string.IsNullOrEmpty(model.Tags))
            {
                var tagsArr = model.Tags.Split(",").ToList();
                if (tagsArr.Any())
                {
                    var savedTags = SavePostTags(savedPost, tagsArr);
                }
            }

            //save persons
            if (!string.IsNullOrEmpty(model.People))
            {
                var peopleArr = model.People.Split(",").ToList();
                if (peopleArr.Any())
                {
                    var savedPeople = SavePostPeople(savedPost, peopleArr);
                }
            }
            _centerService.DeleteCenterCategories(savedPost.Id);
            //save categories
            if (model.SelectedCategories != null && model.SelectedCategories.Any())
            {
                _centerService.SaveCenterCategories(savedPost.Id, model.SelectedCategories);
            }
            return post;
        }

        public Post Save(Post post)
        {
            post.CenterTypeId = (int)CenterTypes.Posts;
            post.UniqueId = Guid.NewGuid();
            return base.AddOrUpdate(post);
        }

        //public new IEnumerable<PostDto> GetListPaged(int pageNumber = 1, int itemsPerPage = 10)
        //{
        //    var postIds = base.GetListPaged(pageNumber, itemsPerPage).Select(p => p.Id);
        //    var postsDto = postIds.Select(GetPost).ToList();
        //    return postsDto;
        //}

        public EditPostViewModel GetPostForEdit(int id)
        {


            var post = base.GetById(id);
            var postCategories = _centerService.GetCenterCategories(id);
            var postTags = GetPostTags(id);
            var postPeople = GetPostPeople(id);
            var postVideo = _videoService.GetByCenterId(id)?.VideoName;
            var postImage = _imageService.GetByCenterId(id)?.ImageName;

            var model = new EditPostViewModel
            {
                Id = post.Id,
                ShortTitle = post.ShortTitle,
                Title = post.Title,
                Description = post.Description,
                Tags = postTags,
                People = postPeople,
                ImageName = postImage,
                VideoName = postVideo,
                SelectedCategories = postCategories.Select(c => c.Id).ToList()
            };
            return model;
        }

        public string GetPostTags(int id)
        {
            var tagIds = _membershipManagementService.GetMemberships(id, RelationTypes.PostTags, false, false)
                .Select(s => s.CenterId).ToList();

            var tags = _tagService.GetDefaultQuery().Where(w => tagIds.Contains(w.Id)).ToList();

            var tagsStr = string.Join(",", tags.Select(t => t.Title));
            return tagsStr;
        }
        public string GetPostPeople(int id)
        {
            var peopleIds = _membershipManagementService.GetMemberships(id, RelationTypes.PostPeople, false, false)
                .Select(s => s.CenterId).ToList();

            var people = _peopleService.GetDefaultQuery().Where(w => peopleIds.Contains(w.Id)).ToList();

            var peopleStr = string.Join(",", people.Select(p => $"{p.Firstname} {p.Lastname}"));
            return peopleStr;

        }

        public async Task<List<PostViewModel>> GetSpecialPostsAsync()
        {
            return await _context.Posts
                        .Where(w => !w.IsDeleted && w.IsSpecialOffer)
                        .Select(s => new PostViewModel
                        {
                            Id = s.Id,
                            Image = _imageService.GetByCenterId(s.Id).ImageName,
                            Title = s.Title,
                            ViewCount = s.ViewCount,
                            PublishDate = s.PublishDate.ToPersianString(),
                            Description = s.Description.TruncateString(200)
                        })
                        .ToListAsync();
        }

        public async Task<List<PostViewModel>> GetTrendTvsAsync()
        {
            return await _context.Posts
                        .Where(w => !w.IsDeleted && w.IsTrendTv)
                        .Select(s => new PostViewModel
                        {
                            Id = s.Id,
                            Image = _imageService.GetByCenterId(s.Id).ImageName,
                            Title = s.Title,
                            ViewCount = s.ViewCount,
                            PublishDate = s.PublishDate.ToPersianString(),
                            Description = s.Description.TruncateString(200)
                        })
                        .ToListAsync();
        }
        public async Task<List<PostViewModel>> GetTopTensAsync()
        {
            return await _context.Posts
                        .Where(w => !w.IsDeleted && w.IsTopTen)
                        .Select(s => new PostViewModel
                        {
                            Id = s.Id,
                            Image = _imageService.GetByCenterId(s.Id).ImageName,
                            Title = s.Title,
                            ViewCount = s.ViewCount,
                            PublishDate = s.PublishDate.ToPersianString(),
                            Description = s.Description.TruncateString(200)
                        })
                        .ToListAsync();
        }

        public async Task<List<PostViewModel>> GetRecentVideosAsync(int count)
        public List<Category> GetPostCategories(int id)
        {
            return _context.CenterCategories.Include(p => p.Category)
                .Where(p => p.CenterId == id && p.IsDeleted == false && p.Category.IsDeleted == false)
                .Select(p => p.Category).ToList();
        }

        public PostDetailsViewModel GetPostDetail(int id)
        {
            var post = base.GetById(id);
            var peopleIds = _membershipManagementService.GetMemberships(id, RelationTypes.PostPeople, false, false)
                .Select(s => s.CenterId).ToList();

            var people = _peopleService.GetDefaultQuery().Where(w => peopleIds.Contains(w.Id)).ToList();

            var categories = GetPostCategories(id);
            var video = _videoService.GetByCenterId(id);
            var image = _imageService.GetByCenterId(id);

            var model = new PostDetailsViewModel();
            model.Id = post.Id;
            model.Title = post.Title;
            model.Description = post.Description;
            model.People = people;
            model.Categories = categories;
            model.VideoName = video.VideoName;
            model.ImageName = image.ImageName;
            return model;
        }

        public async Task<List<PostViewModel>> GetRecentVideosAsync()
        {
            return await _context.Posts
                        .Where(w => !w.IsDeleted)
                        .Select(s => new PostViewModel
                        {
                            Id = s.Id,
                            Image = _imageService.GetByCenterId(s.Id).ImageName,
                            Title = s.Title,
                            ViewCount = s.ViewCount,
                            PublishDate = s.PublishDate.ToPersianString(),
                            Description = s.Description.TruncateString(200)
                        })
                        .OrderByDescending(o => o.Id)
                        .Take(count)
                        .ToListAsync();
        }

        public async Task<List<PostViewModel>> GetMostViewedPostAsync()
        {
            return await _context.Posts
                        .Where(w => !w.IsDeleted)
                        .Select(s => new PostViewModel
                        {
                            Id = s.Id,
                            Image = _imageService.GetByCenterId(s.Id).ImageName,
                            Title = s.Title,
                            ViewCount = s.ViewCount,
                            PublishDate = s.PublishDate.ToPersianString(),
                            Description = s.Description.TruncateString(200)
                        })
                        .OrderByDescending(o => o.ViewCount)
                        .Take(12)
                        .ToListAsync();
        }

        public async Task<List<PostViewModel>> GetHottestPostAsync()
        {
            return await _context.Posts
                        .Where(w => !w.IsDeleted)
                        .Select(s => new PostViewModel
                        {
                            Id = s.Id,
                            Image = _imageService.GetByCenterId(s.Id).ImageName,
                            Title = s.Title,
                            ViewCount = s.ViewCount,
                            PublishDate = s.PublishDate.ToPersianString(),
                            Description = s.Description.TruncateString(200)
                        })
                        .OrderByDescending(o => o.ViewCount).ThenByDescending(o => o.Id)
                        .Take(12)
                        .ToListAsync();
        }

        public async Task<List<PostViewModel>> GetControversialPostAsync()
        {
            return await _context.Posts
                        .Where(w => !w.IsDeleted)
                        .Select(s => new PostViewModel
                        {
                            Id = s.Id,
                            Image = _imageService.GetByCenterId(s.Id).ImageName,
                            Title = s.Title,
                            ViewCount = s.ViewCount,
                            PublishDate = s.PublishDate.ToPersianString(),
                            Description = s.Description.TruncateString(200)
                        })
                        .OrderByDescending(o => o.ViewCount).ThenByDescending(o => o.Id)
                        .Take(12)
                        .ToListAsync();
        }
    }
}
