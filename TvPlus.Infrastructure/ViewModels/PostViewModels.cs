using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Web.Mvc;
using TvPlus.Core.Models;

namespace TvPlus.Infrastructure.ViewModels
{
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
}
