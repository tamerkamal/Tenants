using System;
using System.Collections.Generic;

namespace Master.Entity.Models
{
    public partial class Tier
    {
        public Tier()
        {
            Subscription = new HashSet<Subscription>();
        }

        public int TierId { get; set; }
        public string TierName { get; set; }
        public string TierDesc { get; set; }

        public virtual ICollection<Subscription> Subscription { get; set; }
    }
}
