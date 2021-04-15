using System;
using System.Collections.Generic;
using System.Text;
using TvPlus.Core.Models;

namespace TvPlus.Infrastructure.Dtos.Post
{
    public class EditPostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortTitle { get; set; }
        public string Description { get; set; }
        public string Context { get; set; }
        public List<PostTagsDto> Tags { get; set; }
        public List<PostPeopleDto> People { get; set; }

    }

    public class PostTagsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
    public class PostPeopleDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
