using System;
using System.Collections.Generic;
using System.Text;

namespace Master.DTO
{
    public class CreateTenantReqDTO
    {
        public int TenantId { get; set; }
        public string SubDomain { get; set; }
        public int SubscriptionId { get; set; }
        public string CognitoPoolId { get; set; }
        public string CognitoPoolArn { get; set; }
        public string CognitoDomain { get; set; }
        public string CognitoClientId { get; set; }
        public string CognitoApiresourceIds { get; set; }
        public string DbConnectionString { get; set; }
    }

    public class CreateTenantResDTO
    {
       
    }
}
