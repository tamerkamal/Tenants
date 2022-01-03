using System;
using System.Collections.Generic;

namespace Master.Entity.Models
{
    public partial class Subscription
    {
        public int SubscriptionId { get; set; }
        public byte[] CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ExpiresOn { get; set; }
        public int TierId { get; set; }
    }
}
