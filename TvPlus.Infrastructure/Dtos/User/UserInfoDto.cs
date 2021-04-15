using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TvPlus.Infrastructure.Dtos.User
{
    public class UserInfoDto
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Avatar { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Information { get; set; }

        public List<string> Roles { get; set; }
    }
}
