using System;
using System.Collections.Generic;
using System.Text;

namespace Master.Entity.Models
{
    public partial class Worker
    {
        public Worker()
        {
            //CodeTable = new HashSet<CodeTable>();
            //CodeTableScheme = new HashSet<CodeTableScheme>();
            //CodeTableType = new HashSet<CodeTableType>();
            //ColorScheme = new HashSet<ColorScheme>();
            //MinorProjectField = new HashSet<MinorProjectField>();
            //MinorProjectFieldList = new HashSet<MinorProjectFieldList>();
            //MinorProjectFieldValue = new HashSet<MinorProjectFieldValue>();
            //RefreshToken = new HashSet<RefreshToken>();
            //ScheduleCreatedByWorkerNavigation = new HashSet<Schedule>();
            //ScheduleCriteria = new HashSet<ScheduleCriteria>();
            //ScheduleCriteriaSetting = new HashSet<ScheduleCriteriaSetting>();
            //ScheduleProjectManager = new HashSet<Schedule>();
            //ScheduleTaskItem = new HashSet<ScheduleTaskItem>();
            //ScheduleTemplate = new HashSet<ScheduleTemplate>();
            //ScheduleTemplateTask = new HashSet<ScheduleTemplateTask>();
            //ScheduleTemplateTaskItem = new HashSet<ScheduleTemplateTaskItem>();
            //ScheduleType = new HashSet<ScheduleType>();
            //WorkerZone = new HashSet<WorkerZone>();
        }

        public int WorkerId { get; set; }
        public int? WorkerCompanyId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public bool StreamNetaccess { get; set; }
        public bool WebsiteAccess { get; set; }
        public bool IpadAccess { get; set; }
        public DateTime? PasswordLastChanged { get; set; }
        public DateTime? LastLogin { get; set; }
        public int? WorkerTypeId { get; set; }
        public string Position { get; set; }
        public int PositionId { get; set; }
        public string StreamId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OtherName { get; set; }
        public string Address { get; set; }
        public string Suburb { get; set; }
        public string State { get; set; }
        public string Postcode { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string PersonalMobile { get; set; }
        public string HomePhoneNo { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string CarRego { get; set; }
        public DateTime? CarRegoExp { get; set; }
        public string Health { get; set; }
        public string Training { get; set; }
        public DateTime? Dob { get; set; }
        public bool ContractSigned { get; set; }
        public DateTime? DateCommenced { get; set; }
        public DateTime? DateProbCompleted { get; set; }
        public DateTime? DatePermCommenced { get; set; }
        public DateTime? DateTerminated { get; set; }
        public string ReasonForLeaving { get; set; }
        public string SecondLanguage { get; set; }
        public bool MainWorker { get; set; }
        public bool IdcardIssued { get; set; }
        public bool VehicleSignage { get; set; }
        public bool PassportIssued { get; set; }
        public bool CompanyManual { get; set; }
        public int? ReportsToWorkerId { get; set; }
        public string Status { get; set; }
        public string ExonetLocId { get; set; }
        public string TaxFileNo { get; set; }
        public string MyobPayCardName { get; set; }
        public bool PayTimesheet { get; set; }
        public double? PayStandardHours { get; set; }
        public int? ExonetAccNoWages { get; set; }
        public int? ExonetAccNoSuper { get; set; }
        public int? ExonetAccNoPayrollTax { get; set; }
        public int? ExonetBranchNo { get; set; }
        public int? ExonetSubAccNo { get; set; }
        public double? PayDefaultKpi { get; set; }
        public byte? PayDefaultMv { get; set; }
        public string PhotoPath { get; set; }
        public byte[] Photo { get; set; }
        public byte[] ThumbPhoto { get; set; }
        public int? OldTechnicianId { get; set; }
        public int? OldEmpId { get; set; }
        public int? OldUserId { get; set; }
        public string OldStreamId { get; set; }
        public bool GenericWindowsLogin { get; set; }
        public decimal? PerfFactor { get; set; }
        public bool? MessageRecip { get; set; }
        public int CustomerId { get; set; }
        public int? DefaultPermId { get; set; }
        public int? ZoneId { get; set; }
        public string DefaultSmsnumber { get; set; }
        public bool CanBeRoutedJobs { get; set; }
        public bool PoliceCheck { get; set; }
        public bool RegionalWorker { get; set; }
        public int DefaultJobSource { get; set; }
        public string GizmoMigrationGuid { get; set; }
        public bool? TrackHours { get; set; }
        public int? OffBoardingTaskId { get; set; }
        public int? OnBoardingTaskId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? LastUpdated { get; set; }
        public DateTime? IpadLastUpdated { get; set; }
        public int? DefaultLocationId { get; set; }
        public string Extension { get; set; }
        public string LitmosId { get; set; }
        public string FullName { get; set; }
        public string FullNameBySurname { get; set; }
        public bool RequireTraining { get; set; }


        //public virtual Company WorkerCompany { get; set; }
        //public virtual WorkerType WorkerType { get; set; }
        //public virtual ICollection<CodeTable> CodeTable { get; set; }
        //public virtual ICollection<CodeTableScheme> CodeTableScheme { get; set; }
        //public virtual ICollection<CodeTableType> CodeTableType { get; set; }
        //public virtual ICollection<ColorScheme> ColorScheme { get; set; }
        //public virtual ICollection<MinorProjectField> MinorProjectField { get; set; }
        //public virtual ICollection<MinorProjectFieldList> MinorProjectFieldList { get; set; }
        //public virtual ICollection<MinorProjectFieldValue> MinorProjectFieldValue { get; set; }
        //public virtual ICollection<RefreshToken> RefreshToken { get; set; }
        //public virtual ICollection<Schedule> ScheduleCreatedByWorkerNavigation { get; set; }
        //public virtual ICollection<ScheduleCriteria> ScheduleCriteria { get; set; }
        //public virtual ICollection<ScheduleCriteriaSetting> ScheduleCriteriaSetting { get; set; }
        //public virtual ICollection<Schedule> ScheduleProjectManager { get; set; }
        //public virtual ICollection<ScheduleTaskItem> ScheduleTaskItem { get; set; }
        //public virtual ICollection<ScheduleTemplate> ScheduleTemplate { get; set; }
        //public virtual ICollection<ScheduleTemplateTask> ScheduleTemplateTask { get; set; }
        //public virtual ICollection<ScheduleTemplateTaskItem> ScheduleTemplateTaskItem { get; set; }
        //public virtual ICollection<ScheduleType> ScheduleType { get; set; }
        //public virtual ICollection<WorkerZone> WorkerZone { get; set; }
    }
}
