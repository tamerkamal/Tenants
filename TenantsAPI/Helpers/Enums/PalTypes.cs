using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum PalTypes
    {
        [Description("Missing Details")]
        MissingDetails,

        [Description("Customer Survey")]
        CustomerSurvey,

        [Description("Quality Inspection")]
        QualityInspection,

        [Description("Follow Up")]
        FollowUp,

        [Description("GE Missing Payment")]
        GEMissingPayment,

        [Description("Missing Payment")]
        MissingPayment,

        [Description("Refund Payable")]
        RefundPayable,

        [Description("Schedule Job")]
        ScheduleJob,

        [Description("Quote Pending")]
        QuotePending,

        [Description("Job Not Closed")]
        JobNotClosed,

        [Description("Partner Support Q")]
        PartnerSupportQ,

        [Description("Remote Support Q")]
        RemoteSupportQ,

        [Description("IT Setup Support Q")]
        ItSetupSupportQ,

        [Description("Job Not Routed")]
        JobNotRouted,

        [Description("Email Customer Invoice")]
        EmailCustomerInvoice,

        [Description("Timeslot Jeopardy")]
        TimeslotJeopardy,

        [Description("OTD Reschedule Requested")]
        OTDRescheduleRequested,

        [Description("Schedule Prescoping")]
        SchedulePrescoping,

        [Description("Schedule Aerial")]
        ScheduleAerial,

        [Description("Prescoping Complete")]
        PrescopingComplete,

        [Description("SV Location Complete")]
        SVLocationComplete,

        [Description("SV Location Complete ASB")]
        SVLocationCompleteASB,

        [Description("Book Civils")]
        BookCivils,

        [Description("Book Civils ASB")]
        BookCivilsASB,

        [Description("Proofing to Civil")]
        ProofingToCivil,

        [Description("Asbestos Complete")]
        AsbestosComplete,

        [Description("Preinspection Complete")]
        PreinspectionComplete,

        [Description("Work Stoppage")]
        WorkStoppage,

        [Description("NBN Site Access")]
        NBNSiteAccess,

        [Description("NBN Hazard")]
        NBNHazard,

        [Description("NBN U-18")]
        NBNU_18,

        [Description("Bulk Recon Inspection")]
        BulkReconInspection,

        [Description("Accept/Reject ToW")]
        AcceptRejectToW,

        [Description("NBN Follow Up")]
        NBNfollowUp,

        [Description("Assign Carp Job")]
        AssignCarpJob,

        [Description("Unassign Carp Job")]
        UnassignCarpJob,

        [Description("Review Required")]
        ReviewRequired,

        [Description("Nbn Audit Level 1")]
        NbnAuditLevel1,

        [Description("Nbn Audit Level 2")]
        NbnAuditLevel2,

        [Description("Nbn Audit Level 3")]
        NbnAuditLevel3,

        [Description("Nbn Audit Level 4")]
        NbnAuditLevel4,

        [Description("TCS Audit Escalation")]
        TCSAuditEscalation,

        [Description("Return to NBN")]
        ReturntoNBN,

        [Description("NBN DBYD At Risk")]
        NBNDBYDAtRisk,

        [Description("Schedule HFC Leadin")]
        ScheduleHFCLeadin,

        [Description("Schedule HFC Testing")]
        ScheduleHFCTesting,

        [Description("Schedule EWP")]
        ScheduleEWP,

        [Description("Schedule Day Traffic Control")]
        ScheduleDayTrafficControl,

        [Description("Schedule Night Traffic Control")]
        ScheduleNightTrafficControl,

        [Description("Schedule TEWP")]
        ScheduleTEWP,

        [Description("Schedule Internals")]
        ScheduleInternals,

        [Description("Schedule Aerial Lead In")]
        ScheduleAerialLeadIn,

        [Description("Schedule HFC Testing Telstra")]
        ScheduleHFCTestingTelstra,

        [Description("Schedule Permit Job")]
        SchedulePermitJob,

        [Description("Schedule HFC MDU Leadin")]
        ScheduleHFCMDULeadin,

        [Description("Schedule MDU Night Traffic Control")]
        ScheduleMDUNightTrafficControl,

        [Description("Schedule MDU Day Traffic Control")]
        ScheduleMDUDayTrafficControl,

        [Description("Schedule MCAD")]
        ScheduleMCAD,

        [Description("HMDU Awaiting Equipment")]
        HMDUAwaitingEquipment,

        [Description("Schedule Install")]
        ScheduleInstall,

        [Description("Schedule PAB Job")]
        SchedulePabJob,

        [Description("Reschedule Job")]
        RescheduleJob,

        [Description("Pre-Install Call")]
        PreInstallCall,

        [Description("Job in Jeopardy")]
        JobInJeopardy,

        [Description("Pending")]
        Pending,

        [Description("IT Premium Phone Q")]
        ITPremiumPhoneQ,

        [Description("Schedule HFC Complex Leadinl")]
        ScheduleHFCComplexLeadin,

        [Description("QTQ Withdrawn Mismatch")]
        QTQWithdrawnMismatch,

        [Description("QTQ Completed Mismatch")]
        QTQCompletedMismatch,

        [Description("QTQ Held Mismatch")]
        QTQHeldMismatch,

        [Description("QTQ Tech-on-Site")]
        QTQTechOnSite,

        [Description("QTQ Close ToW")]
        QTQCloseToW,

        [Description("QTQ Activation Mismatch")]
        QTQActivationMismatch,

        [Description("QTQ Assigned Mismatch")]
        QtqAssignedMismatch
    }
}