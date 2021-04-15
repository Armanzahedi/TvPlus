using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using TvPlus.Core.Models;
using TvPlus.Infrastructure.Dtos.Post;

namespace TvPlus.Web.Areas.Management.ViewModels
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
        public string VideoPath { get; set; }
        public string Context { get; set; }
        public List<PostTagsViewModel> Tags { get; set; }
        public List<PostPeopleViewModel> People { get; set; }
        public Video Video { get; set; }
        public Image Image { get; set; }
    }

    public class PostTagsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Selected { get; set; }
    }
    public class PostPeopleViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Selected { get; set; }
    }
}
