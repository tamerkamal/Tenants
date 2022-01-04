using System;
using System.Collections.Generic;
using System.Text;

namespace Master.DTO
{
    public class CreateSubscriptionReqDTO
    {
        public int SubscriptionId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ExpiresOn { get; set; }
        public int TierId { get; set; }
    }  
    
    public class CreateSubscriptionResDTO
    {
        public int SubscriptionId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ExpiresOn { get; set; }
        public int TierId { get; set; }
    }
}
