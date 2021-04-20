using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Web.Mvc;
using TvPlus.Core.Models;

namespace TvPlus.Infrastructure.ViewModels
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ViewCount { get; set; }
        public string PublishDate { get; set; }
        public string Image { get; set; }
    }

    public class PostCategoryViewModel
    {
        private List<PostViewModel> _hottestPost;
        public List<PostViewModel> HottestPost
        {
            get { return _hottestPost ?? (_hottestPost = new List<PostViewModel>()); }
            set { _hottestPost = value; }
        }

        private List<PostViewModel> _controversialPost;
        public List<PostViewModel> ControversialPost
        {
            get { return _controversialPost ?? (_controversialPost = new List<PostViewModel>()); }
            set { _controversialPost = value; }
        }

        private List<PostViewModel> _mostViewedPost;
        public List<PostViewModel> MostViewedPost
        {
            get { return _mostViewedPost ?? (_mostViewedPost = new List<PostViewModel>()); }
            set { _mostViewedPost = value; }
        }

        private List<PostViewModel> _recentVideos;
        public List<PostViewModel> RecentVideos
        {
            get { return _recentVideos ?? (_recentVideos = new List<PostViewModel>()); }
            set { _recentVideos = value; }
        }
    }
    public class PostGridViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PublishDate { get; set; }
        public int ViewCount { get; set; }
    }
    public class EditPostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortTitle { get; set; }
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string Description { get; set; }
        public string Context { get; set; }
        public string Tags { get; set; }
        public string People { get; set; }
        public string VideoName { get; set; }
        public string ImageName { get; set; }
        public EditMode EditMode { get; set; }
        public List<int> SelectedCategories { get; set; }
    }

    public class PostCategoriesSelectList
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Selected { get; set; }
    }
    public enum EditMode
    {
        Create = 1,
        Edit = 2
    }

    public class PostDetailsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string VideoName { get; set; }
        public string ImageName { get; set; }
        private List<Category> _categories;
        public List<Category> Categories
        {
            get { return _categories ?? (new List<Category>()); }
            set { _categories = value; }
        }

        private List<People> _people;

        public List<People> People
        {
            get { return _people ?? (new List<People>()); }
            set { _people = value; }
        }


    }
}
