using System;
using System.Collections.Generic;
using System.Text;

namespace Master.DTO
{
    public class CreateTenantReqDTO
    {
        public int TenantId { get; set; }
        public int TierId { get; set; }
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
        public int SubscriptionId { get; set; }

        public bool IsCreateUserPoolSucceeded { get; set; }=false;
        public bool IsCreatUserPoolClientSucceeded { get; set; } = false;
        public bool IsCreatedUserPoolGroupSucceeded { get; set; } = false;
        public bool IsCreatedUserSucceeded { get; set; } = false;
        public bool IsAddUserToGroupSucceeded { get; set; } = false;
        public bool IsUpdatedAuthorizersSucceeded { get; set; } = false;

        public bool IsCreateTenantDatabaseSucceeded { get; set; } = false;
        public bool IsCreateSubscriptionSucceeded { get; set; } = false;
        public bool IsCreateTenantSucceeded { get; set; } = false;

        public string ResponseMessage { get; set; }

        public static readonly   string CreateUserPoolFailed = "Creation of Pool failed!";
        public static readonly string CreateUserPoolClientFailed = "Creation of Client failed!";
        public static readonly string CreateUserPoolGroupFailed = "Creation of Group failed!";
        public static readonly string CreateUserFailed = "Creation of User failed!";
        public static readonly string AddUserToGroupFailed = "Adding User To Group failed!";
        public static readonly string UpdatedAuthorizersFailed = "Updating APIGateway Authorizers Arns failed!";

        public static readonly string CreateTenantDatabaseFailed = "Create Tenant Database failed!";
        public static readonly string CreateSubscriptionFailed = "Create Subscription failed!";
        public static readonly string CreateTenantFailed = "Create Tenant failed!";
      
    }
}
