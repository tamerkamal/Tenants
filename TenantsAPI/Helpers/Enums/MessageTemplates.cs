using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum MessageTemplates
    {
        [Description("Created when right-click on date in Capacity screen")]
        CapacitySMS = 3,

        [Description("Job Visit Tech StreamNET Notification")]
        JobVisitTechStreamNetNotification = 17,

        [Description("Pic's confirmation")]
        PicsConfirmation = 26,

        [Description("Pic's confirmation iinet")]
        PicsConfirmationiiNet,

        [Description("Job Visit Tech SMS Notification")]
        JobVisitTechSmsNotification = 29,

        [Description("Customer Job Visit Confirmation ")]
        CustomerJobVisitConfirmation = 30,

        [Description("Customer Job Visit Confirmation iinet")]
        CustomerJobVisitConfirmationiiNet,

        [Description("New Job Issue Notification Email")]
        NewJobIssueNotificationEmail = 34,

        [Description("Email Notification for CMC Coordinator")]
        EmailNotificationCMCCoordinator = 35,

        [Description("Notifies the recipient they have been invited to a meeting")]
        MeetingNotification = 52,

        [Description("Customer SMS for booked jobs with date")]
        CustomerSmsForBookedJobsWithDate = 131,

        [Description("Customer SMS for booked jobs with date")]
        CustomerSmsForBookedJobsWithoutDate = 132,

        [Description("TriggerAction")]
        TriggerAction = 326,

        [Description("T2HPREMIUM  Frist Closed Job Email")]
        T2HPREMIUMFristClosedJobEmail = 341,

        [Description("Close Quote Job From Wizard")]
        CloseQuoteJobFromWizard = 374,

        [Description("Missing Payment SMS")]
        MissingPaymentSms = 430,

        [Description("Collection Report Email")]
        CollectionReportEmail = 431, 
    
        [Description("Message Template for Task Comment Added")]
        TaskCommentAdded = 33

    }
}