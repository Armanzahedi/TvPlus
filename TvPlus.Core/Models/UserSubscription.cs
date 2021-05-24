using System;
using System.Collections.Generic;
using System.Text;

namespace TvPlus.Core.Models
{
    public class UserSubscription : IBaseEntity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public int SubscriptionId { get; set; }
        public SubscriptionPackage SubscriptionPackage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }

        public DateTime InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string InsertUser { get; set; }
        public string UpdateUser { get; set; }
        public bool IsDeleted { get; set; }
    }
}
