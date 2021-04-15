using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using TvPlus.Core.Models;
using TvPlus.DataAccess;
using TvPlus.DataAccess.Repositories;
using TvPlus.Infrastructure.Dtos.Post;
using TvPlus.Infrastructure.ViewModels;
using TvPlus.Services.Membership;
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

    }

    public class PostService : PostRepository, IPostService
    {
        private readonly IMapper _mapper;
        private readonly ITagService _tagService;
        private readonly IPeopleService _peopleService;
        private readonly IVideoService _videoService;
        private readonly IImageService _imageService;
        private readonly IMembershipManagementBaseService _membershipManagementService;
        private readonly MyDbContext _context;

        public PostService(
            IMapper mapper,
            IMembershipManagementBaseService membershipManagementService,
            ITagService tagService,
            IPeopleService peopleService,
            MyDbContext context, IVideoService videoService, IImageService imageService) : base(context)
        {
            _mapper = mapper;
            _context = context;
            _videoService = videoService;
            _imageService = imageService;
            _membershipManagementService = membershipManagementService;
            _tagService = tagService;
            _peopleService = peopleService;
        }

        //public List<PostTagsDto> SavePostTags(int postId, List<PostTagsDto> tags)
        //{
        //    var message = string.Empty;
        //    var post = base.GetById(postId);
        //    var oldTagIds = _membershipManagementService.GetMemberships(postId, RelationTypes.PostTags, false, false)
        //        .Select(s => s.CenterId).ToList();

        //    var oldTags = _tagService.GetDefaultQuery().Where(w => oldTagIds.Contains(w.Id)).ToList();
        //    oldTags.ForEach(item =>
        //        {
        //            var memberId = _membershipManagementService.GetMemberships(post.Id,item.Id,  RelationTypes.PostTags,
        //                false, false).FirstOrDefault()?.MemberId;
        //            if (memberId != null)
        //            {
        //             _membershipManagementService.ArchiveMembership(memberId.Value,DateTime.Now,out message);
        //            }
        //        });

        //    var dto = new List<PostTagsDto>();
        //    tags.ForEach(item =>
        //    {
        //        //map tag
        //        var tag = _mapper.Map<Tag>(item);

        //        if (tag.Id == 0)
        //        {
        //            tag.CenterTypeId = (int)CenterTypes.Tags;
        //            tag.UniqueId = Guid.NewGuid();
        //            _tagService.Save(tag);
        //        }
        //        else
        //        {
        //            tag = _tagService.GetById(tag.Id);
        //        }

        //        var memberId = _membershipManagementService.GetMemberships(post.Id, tag.Id, RelationTypes.PostTags,
        //            false, false).FirstOrDefault()?.MemberId;

        //        _membershipManagementService.RegisterMembership(post, tag, DateTime.Now, null, out message,
        //            memberId, RelationTypes.PostTags, null);
        //        var tagDto = _mapper.Map<PostTagsDto>(tag);
        //        dto.Add(tagDto);
        //    });
        //    return dto;
        //}

        public List<Tag> SavePostTags(Post post, List<string> tags)
        {
            var message = string.Empty;
            var result = new List<Tag>();

            var prevMembers =  _membershipManagementService.GetSelfMemberships(post,RelationTypes.PostTags, false);
            foreach (var item in prevMembers)
            {
                _membershipManagementService.DeleteMembership(item,null,out message);
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

            var post = new Post
            {
                Id = model.Id,
                PublishDate = DateTime.Now,
                ShortTitle = model.ShortTitle,
                Title = model.Title,
                Description = model.Description,
                Context = model.Context
            };
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
            //save specials


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
            var postDto = _mapper.Map<PostDto>(post);
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
               VideoName = postVideo
            };
            return model;
        }

        public string GetPostTags(int id)
        {
            var tagIds = _membershipManagementService.GetMemberships(id, RelationTypes.PostTags, false, false)
                .Select(s => s.CenterId).ToList();

            var tags = _tagService.GetDefaultQuery().Where(w => tagIds.Contains(w.Id)).ToList();

            var tagsStr = string.Join(",",tags.Select(t=>t.Title));
            return tagsStr;
        }
        public string GetPostPeople(int id)
        {
            var peopleIds = _membershipManagementService.GetMemberships(id, RelationTypes.PostPeople, false, false)
                .Select(s => s.CenterId).ToList();

            var people = _peopleService.GetDefaultQuery().Where(w => peopleIds.Contains(w.Id)).ToList();

            var peopleStr = string.Join(",", people.Select(p=>$"{p.Firstname} {p.Lastname}"));
            return peopleStr;

        }
    }
}
