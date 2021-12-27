using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum Settings
    {
        [Description("Email when new worker added")]
        EmailWhenNewWorkerAdded = 1,

        [Description("Email when new company added")]
        EmailWhenNewCompanyAdded = 2,

        [Description("Email when any worker details changed")]
        EmailWhenAnyWorkerDetailsChanged = 3,

        [Description("Email when any company details changed")]
        EmailWhenAnyCompanyDetailsChanged = 4,

        [Description("Email when company bank details changed")]
        EmailWhenCompanyBankDetailsChanged = 5,

        [Description("Location of Westpac CC Payment website")]
        LocationOfWestpacCcPaymentWebsite = 15,

        [Description("Item ID for Charge to Store Item for HN")]
        ItemIDforChargetoStoreItemforHn = 18,

        [Description("Message Template for New CD job booking notification")]
        MessageTemplateforNewCdJobBookingNotification = 19,


        [Description("Number of months to update Payroll Tax Exemption status")]
        NumberOfMonthsToUpdatePayrollTaxExemptionStatus = 31,

        [Description("Item ID for HN Pickups")]
        ItemIdForHnPickups = 34,

        [Description("PU item")]
        PUItem = 34,

        [Description("Additional text for Customer SMS Confirmation for jobs with PU")]
        AdditionalTextForCustomerSMSConfirmationForJobsWithPU = 35,

        [Description("Additional text for Customer SMS Confirmation for jobs without PU")]
        AdditionalTextForCustomerSMSConfirmationForJobsWithoutPU = 36,

        [Description("GE Finance CustomerID for billing GE Finance Job Items")]
        GEFinanceCustomerID = 56,

        [Description("Notfies FOMs and ROMs when a Special Arrangement job is Created, Canceled, scheduled or Rescheduled")]
        NotfiesFoMsAndRoMswhenaSpecialArrangementJobisCreatedCanceledScheduledRescheduled = 64,

        [Description("SL Appointment Notification Jobtypes")]
        SLAppointmentNotificationJobTypes = 65,

        [Description("In Home Quote ItemID for setting this item always to first visit in T2h Quote Process")]
        InHomeQuoteItemIdForSettingThisItemAlwaysToFirstVisitInT2hQuoteProcess = 66,

        [Description("Ipad Library Photo URL")]
        IpadLibraryPhotoURL = 67,

        [Description("SV Job Type ID")]
        SVJobTypeId = 68,

        [Description("Notifies FOMs and ROMs when Tech Capacity has gone below required Level")]
        NotifieFOMsAndROMsWhenTechCapacityHasGoneBlowRequiredLevel = 69,

        [Description("Discount Promo Item")]
        DiscountPromoItem = 71,

        [Description("Default Save location for iPad Photos")]
        DefaultSaveLocationIPadPhotos = 73,

        [Description("CTS Item ID")]
        CTSItemId = 75,

        [Description("Reason ID for customer communication entered Comments and feedbacks")]
        ReasonIdCustomerCommunicationEnteredCommentsFeedBacks = 78,

        [Description("NOC Worker")]
        NocWorker = 80,

        [Description("Full Time Worker ID")]
        FullTimeWorkerId = 81,

        [Description("CST Worker ID")]
        CSTWorkerId = 82,

        [Description("Potential Safety Issue – the technician has been on site without contact 15% longer than expected. Call to verify technician is OK! If needed follow up with contact to the customer or Field Supervisor as appropriate. The safety of the technician MUST be verified. Raise Feedback Log as necessary")]
        DispatchAlert = 83,

        [Description("OHS Dispatch Alert Notify WorkerID")]
        OhsDispatchAlertNotifyWorkerId = 84,

        [Description("Message Template for Instore support thanks")]
        MessageTemplateForInstoreSupportThanks = 88,

        [Description("Email when any worker Status changed")]
        EmailWhenAnyWorkerStatusChanged = 95,

        [Description("OHS W0601 document Path")]
        OHS_W0601_Path = 106,

        [Description("Form Field Questions for NBNAudit Form")]
        FormFieldQuestionsforNBNAuditForm = 112,

        [Description("frmNBNAudit Issue Type ID")]
        NBNAuditIssueTypeId = 114,

        [Description("Form Field Audit Questions for TATA")]
        FormFieldAuditQuestionsforTATA = 154,

        [Description("ItemID for T2HGoBack")]
        ItemIDT2HGoBack = 156,

        [Description("T2HPremuimContractTemplates")]
        T2HPremuimContractTemplates = 173,

        [Description("Message Template for Voucher hn IT")]
        MessageTemplateForVoucherHnIT = 174,

        [Description("Google Maps API Geocode Link")]
        GoogleMapsApiGeocodeLink = 217,

        [Description("Job Type Pending Reason")]
        JobTypePendingReason = 230,

        [Description("Email when any worker is being off-boarded")]
        EmailWhenAnyWorkerIsBeingOffBoarded = 260,

        [Description("SettingID")]
        SettingId = 120,

        [Description("EmailId")]
        Email = 121,

        [Description("AV feedback")]
        AVFeedback = 122,

        [Description("capalertleve")]
        capalertleve = 124,

        [Description("avgtechperts")]
        avgtechperts = 125,

        [Description("skptsactual")]
        SkptsActual = 127,

        [Description("srptsactual")]
        SrptsActual = 128,

        [Description("mnptsactual")]
        MnptsActual = 129,

        [Description("chris.peden@tech2home.com.au,Jonathan.Hadchiti@tech2home.com.au,Daniel.Enayati@tech2.com.au")]
        OhsIncidentsCompanyAssetTickBoxNotification = 137,

        [Description("Setting for ItemID for BBU Scope checked on job completion on the iPad")]
        SettingforItemIDforBbuScopecheckedonjobcompletionontheiPad = 140,

        [Description("Pit A Item")]
        PitAItem = 168,

        [Description("Pit B Item")]
        PitBItem = 169,

        [Description("Duct Item")]
        DuctItem = 170,

        [Description("Pillar Item")]
        PillarItem = 171,

        [Description("Item UOM")]
        ItemUom = 212,

        [Description("Task Code UOM")]
        TaskCodeUom = 213,

        [Description("IncidentNotificationOther@tech2.com.au")]
        IncidentReportNotificationRecipient = 222,

        [Description("Booking wizard JobField1 dropdown values")]
        BookingWizardJobField1dropdownValues = 250,

        [Description("Allowed File Extensions")]
        AllowedFileExtensions,

        [Description("JTA_actions not in pal.paltype")]
        JtaActions,

        [Description("Message Template for New Task Created")]
        MessageTemplateForNewTaskCreated = 160
    }
}