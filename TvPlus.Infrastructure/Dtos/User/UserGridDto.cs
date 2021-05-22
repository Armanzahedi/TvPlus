﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TvPlus.Infrastructure.Dtos.User
{
    public class UserGridDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }
    }
}
