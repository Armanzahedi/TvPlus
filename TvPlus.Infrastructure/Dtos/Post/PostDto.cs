using System;
using System.Collections.Generic;
using System.Text;

namespace TvPlus.Infrastructure.Dtos.Post
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortTitle { get; set; }
        public string Description { get; set; }
        public string Context { get; set; }
        public List<PostTagsDto> Tags { get; set; }
        public List<PostPeopleDto> People { get; set; }
    }
}
