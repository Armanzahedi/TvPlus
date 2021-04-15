using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TvPlus.Core.Models
{
    public interface IBaseEntity
    {
        int Id { get; set; }
        DateTime InsertDate { get; set; }
        DateTime? UpdateDate { get; set; }
        [MaxLength(100)]
        string InsertUser { get; set; }
        [MaxLength(100)]
        string UpdateUser { get; set; }
        bool IsDeleted { get; set; }
    }
}
