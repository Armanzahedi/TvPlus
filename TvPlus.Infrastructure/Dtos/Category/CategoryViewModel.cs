using System;
using System.Collections.Generic;
using System.Text;

namespace TvPlus.Infrastructure.Dtos.Category
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int? ParentId { get; set; }
        public bool Show { get; set; }
    }
}
