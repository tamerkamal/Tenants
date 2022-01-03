using System;
using System.Collections.Generic;

namespace Master.Entity.Models
{
    public partial class Tenant
    {
        public int TenantId { get; set; }
        public string SubDomain { get; set; }
        public string CognitoPoolId { get; set; }
        public string CognitoPoolArn { get; set; }
        public string CognitoDomain { get; set; }
        public string CognitoClientId { get; set; }
        public string CognitoApiresourceIds { get; set; }
    }
}
