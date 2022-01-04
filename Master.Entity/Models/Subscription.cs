using System;
using System.Collections.Generic;

namespace Master.Entity.Models
{
    public partial class Subscription
    {
        public Subscription()
        {
            Tenant = new HashSet<Tenant>();
        }

        public int SubscriptionId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ExpiresOn { get; set; }
        public int TierId { get; set; }

        public virtual Tier Tier { get; set; }
        public virtual ICollection<Tenant> Tenant { get; set; }
    }
}
