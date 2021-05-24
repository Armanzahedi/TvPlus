using System;
using System.Collections.Generic;
using System.Text;

namespace TvPlus.Core.Models
{
    public class PVideos
    {
        public int Id { get; set; }
        public int VideoId { get; set; }
        public string Status { get; set; }
        public int? Converted { get; set; }
        public string Videolink { get; set; }
        public string Videolinkconverted { get; set; }
        public int? Length { get; set; }
        public int? AdminId { get; set; }
        public int? PollId { get; set; }
        public long? UserSenderId { get; set; }
        public string Title { get; set; }
        public string SeoTitle { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public int? CommentLimit { get; set; }
        public int? ShowInVarzesh3 { get; set; }
        public string CategorySlug { get; set; }
        public int? FlagNum { get; set; }
        public int? LikeNum { get; set; }
        public int? ViewNum { get; set; }
        public int? CommentRead { get; set; }
        public int? CommentUnRead { get; set; }
        public int? SocialUserId { get; set; }
        public int? SocialSelected { get; set; }
        public int? SocialShowInMain { get; set; }
        public DateTime? Published { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public string CreatedAdminId { get; set; }
        public string UpdatedAdminId { get; set; }
    }
    public class PVideo_Tag
    {
        public int Id { get; set; }
        public int VideoId { get; set; }
        public int TagId { get; set; }
    }

    public class PVideo_Convert
    {
        public int Id { get; set; }
        public int VideoId { get; set; }
        public int BitRate { get; set; }
        public int Height { get; set; }
        public int Duration { get; set; }
        public int Status { get; set; }
        public string Errors { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public string ErrorStep { get; set; }
    }

    public class PVideo_Category
    {
        public int Id { get; set; }
        public int VideoId { get; set; }
        public int CategoryId { get; set; }
    }

    public class PTags
    {
        public int Id { get; set; }
        public int TagId { get; set; }
        public string Title { get; set; }
    }

    public class PComments
    {
        public long Id { get; set; }
        public int VideoId { get; set; }
        public int UserId { get; set; }
        public long Parent { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Content { get; set; }
        public string IP { get; set; }
        public string Agent { get; set; }
        public int LikeNum { get; set; }
        public int DislikeNum { get; set; }
        public byte Status { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
        public byte CreatedAdminId { get; set; }
        public byte UpdatedAdminId { get; set; }
    }
}
