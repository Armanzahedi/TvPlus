using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TvPlus.Core.Models
{
    public class User : IdentityUser
    {
        public string Avatar { get; set; }
        [MaxLength(300)]
        public string FirstName { get; set; }
        [MaxLength(300)]
        public string LastName { get; set; }
        public string Information { get; set; }
        public int ZuserId { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
