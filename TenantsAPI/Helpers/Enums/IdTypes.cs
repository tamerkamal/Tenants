using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum IdTypes
    {
        [Description("Activity")]
        Activity,

        [Description("ActivityProject")]
        ActivityProject,

        [Description("ActivityProjectRegion")]
        ActivityProjectRegion,

        [Description("ActivityType")]
        ActivityType,

        [Description("ActivityOriginator")]
        ActivityOriginator,

        [Description("Company")]
        Company,

        [Description("Comment")]
        Comment,

        [Description("ComplianceStatusID")]
        ComplianceStatusId,

        [Description("CompanyPtexemption")]
        CompanyPtexemption,

        [Description("CompanyPublicLiability")]
        CompanyPublicLiability,

        [Description("FormLink ")]
        FormLink,

        [Description("IssueType")]
        IssueType,

        [Description("Inv")]
        Inv,

        [Description("JobVisit")]
        JobVisit,

        [Description("Job")]
        Job,

        [Description("JobDefect")]
        JobDefect,

        [Description("JobItem")]
        JobItem,
        
        [Description("ProjectSkill")]
        ProjectSkill,

        [Description("JobStatusAllowed")]
        JobStatusAllowed,

        [Description("FormResponse")]
        FormResponse,

        [Description("formsetuplink")]
        FormSetupLink,

        [Description("Worker")]
        Worker,

        [Description("WorkerType")]
        WorkerType,

        [Description("WorkerSkill")]
        WorkerSkill,

        [Description("WorkerProjectRegion")]
        WorkerProjectRegion,

        [Description("WorkerProject")]
        WorkerProject,

        [Description("Permission")]
        Permission,

        [Description("Project")]
        Project,

        [Description("ProjectRegion")]
        ProjectRegion,

        [Description("JobType")]
        JobType,

        [Description("Item")]
        Item,

        [Description("Skill")]
        Skill,

        [Description("Customer")]
        Customer,

        [Description("CustomerContractEntitlement")]
        CustomerContractEntitlement,

        [Description("CustomerContract")]
        CustomerContract,

        [Description("Group")]
        Group,

        [Description("Course")]
        Course,

        [Description("Category")]
        Category,

        [Description("FormQ")]
        FormQ,

        [Description("FormField")]
        FormField,

        [Description("FormFieldValueList")]
        FormFieldValueList,

        [Description("LinkedDocument")]
        LinkedDocument,

        [Description("Location")]
        Location,

        [Description("Log")]
        Log,

        [Description("JobID")]
        JobId,

        [Description("ProjectTimeslot")]
        ProjectTimeslot,

        [Description("Reason")]
        Reason,

        [Description("SalesEnquiry")]
        SalesEnquiry,


        [Description("Incident")]
        Incident,

        [Description("IncidentWorker")]
        IncidentWorker,

        [Description("Investigation")]
        Investigation,

        [Description("ScheduleTemplateTask")]
        ScheduleTemplateTask,

        [Description("ScheduleTemplateTaskItem")]
        ScheduleTemplateTaskItem,

        [Description("TaskClass")]
        TaskClass,

        [Description("WorkerCapacity")]
        WorkerCapacity,

        [Description("SIFol")]
        SIFol,

        [Description("Test")]
        Test,

        [Description("AssetType")]
        AssetType,

        [Description("AssetSkill")]
        AssetSkill,

        [Description("Asset")]
        Asset,

        [Description("WorkerAsset")]
        WorkerAsset,

        [Description("Warehouse")]
        Warehouse,

        [Description("WizardProject")]
        WizardProject,
      

        [Description("Task")]
        Task,

        [Description("Type")]
        Type
    }
}