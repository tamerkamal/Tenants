namespace Tenants.Helpers.Constants
{
    public static class Permissions
    {
        public const string PolicyPrefix = "PERMISSION";

        public static class WorkerPermissions
        {
            public const int RoutingLimitedFunctions = 214;
            public const int WorkerDetailsRemoveWorkerGroups = 1068;
            public const int WorkerDetailsOverrideInvOrAssetCheck = 1104;
            public const string RoutBypassRoutingCheck = "Rout:bypass skill routing check";
            public const int PrimeRouter = 1725;
            public const int IPadSetupShowAllLibrary = 878;
            public const int WorkerDetailsClearAll = 1454;
        }

        public static class CustomerContractPermissions
        {
            public const int AllowEditContract = 793;
        }

        public static class JobPermissions
        {
            // Enables the Pay Refund button on the Account tab of the Job Details screen.
            public const int JobPayRefund = 122;

            // Allows users to pay refund less than $ 375.
            public const int JobPayRefundlessThan375 = 197;

            // Allows users to pay a authorize a refund between $ 375 and $ 750
            public const int JobPayRefundbetween375and750 = 198;

            // Allows users to pay a refund greater than $ 750
            public const int JobPayRefundGreaterThan750 = 199;

            // Allows users with permission to add items to a job that require permission
            public const int JobPopulatePermissionItems = 200;

            //This permission is used to limit the options in the dispatch screen for subcontractors accessing the system.
            public const int DispatchLimitedFunctions = 215;

            //This permission is used to Search Combo Permission FormParent.
            public const int LimitedSerachJobOnly = 871;

            //This permission is used to Show Partner Updated options in the dispatch screen 
            public const int DispatchShowPartnerUpdated = 910;

            //Dont't Send SMS  New - Reschedul - schedule Job  
            public const int JobDontSendSMS = 994;

            //A permission to load limited jobs only for the Bulk Routing screen and job screen access 
            public const int BulkRouting_Limited_Functions = 1099;
        }

        public static class CapacityPermissions
        {
            //This permission is used to limit the options in the tech availability screen for subcontractors accessing the system. Only teams that the user is a member of are loaded.
            public const int CapacityLimitedTeams = 216;

        }

        public static class PalPermissions
        {
            //This permission permits the user to only view jobs that are assigned to their team or teams that they lead or they are a member of a group that leads
            public const int PALLimitesUser = 245;

            //Show columns Type,Job,Partner,Action
            public const int PALViewAllPALScreenColums = 1003;
        }
    }
}