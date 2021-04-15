using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TvPlus.Core.Models
{
    public class ContactUs : IBaseEntity
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(300)]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        [MaxLength(300)]
        public string SectionOneTitle { get; set; }
        [Required]
        [MaxLength(300)]
        public string SectionOneDescription { get; set; }
        [Required]
        [MaxLength(300)]
        public string SectionTwoTitle { get; set; }
        [Required]
        [MaxLength(300)]
        public string SectionTwoDescription { get; set; }
        [Required]
        [MaxLength(300)]
        public string SectionThreeTitle { get; set; }
        [Required]
        [MaxLength(300)]
        public string SectionThreeDescription { get; set; }
        [Required]
        [MaxLength(300)]
        public string SectionFourTitle { get; set; }
        [Required]
        [MaxLength(300)]
        public string SectionFourDescription { get; set; }
        [Required]
        [MaxLength(300)]
        public string SectionFiveTitle { get; set; }
        [Required]
        [MaxLength(300)]
        public string SectionFiveDescription { get; set; }
        [Required]
        [MaxLength(300)]
        public string SectionSixTitle { get; set; }
        [Required]
        [MaxLength(300)]
        public string SectionSixDescription { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        [MaxLength(100)]
        public string InsertUser { get; set; }
        [MaxLength(100)]
        public string UpdateUser { get; set; }

        public bool IsDeleted { get; set; }
    }
}
