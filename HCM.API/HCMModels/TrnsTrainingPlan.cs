using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsTrainingPlan
    {
        public TrnsTrainingPlan()
        {
            MstTrainingAttachments = new HashSet<MstTrainingAttachment>();
            MstTrainingFeedbacks = new HashSet<MstTrainingFeedback>();
            TrnsTrainingAttendanceAttachments = new HashSet<TrnsTrainingAttendanceAttachment>();
            TrnsTrainingAttendances = new HashSet<TrnsTrainingAttendance>();
            TrnsTrainingEvaluations = new HashSet<TrnsTrainingEvaluation>();
            TrnsTrainingFeedbacks = new HashSet<TrnsTrainingFeedback>();
            TrnsTrainingPlanDetails = new HashSet<TrnsTrainingPlanDetail>();
        }

        public int Id { get; set; }
        public string TrainingName { get; set; }
        public int? TrainingCourseId { get; set; }
        public int? TrainingProviderId { get; set; }
        public int? TrainingVenueId { get; set; }
        public string Mode { get; set; }
        public string Type { get; set; }
        public string TrainerName { get; set; }
        public int? DepartmentId { get; set; }
        public int? DesignationId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int? ParticipantNum { get; set; }
        public string Methodolgy { get; set; }
        public bool? FlgCertificate { get; set; }
        public string ReqTools { get; set; }
        public decimal? TrainingBudget { get; set; }
        public decimal? VenueBudget { get; set; }
        public decimal? AdminBudget { get; set; }
        public decimal? TotalBudget { get; set; }
        public int? BudgetId { get; set; }
        public bool? FlgEssPublished { get; set; }
        public bool? FlgAlertToAdmin { get; set; }
        public string UserCode { get; set; }
        public string Purpose { get; set; }
        public bool? FlgClose { get; set; }
        public string Need { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public int? TrainingCategoryId { get; set; }
        public int? Batch { get; set; }
        public int? TrainingDuration { get; set; }
        public decimal? HoursPerDay { get; set; }
        public int? PlanId { get; set; }
        public string PlanDescription { get; set; }
        public decimal? TotalHours { get; set; }
        public bool? FlgDetailBudget { get; set; }
        public short? DocType { get; set; }
        public int? DocNum { get; set; }
        public string DocStatus { get; set; }
        public string DocStatusLov { get; set; }
        public string DocAprStatus { get; set; }
        public string DocAprStatusLov { get; set; }
        public int? EmpId { get; set; }
        public string TrainingType { get; set; }
        public string Dimension { get; set; }
        public string AttendanceBy { get; set; }
        public decimal? TotalTrainerHours { get; set; }

        public virtual MstTrainingBudget Budget { get; set; }
        public virtual MstEmployee Emp { get; set; }
        public virtual MstTrainingCategory TrainingCategory { get; set; }
        public virtual MstTrainingCourse TrainingCourse { get; set; }
        public virtual MstTrainingProvider TrainingProvider { get; set; }
        public virtual MstTrainingVenue TrainingVenue { get; set; }
        public virtual ICollection<MstTrainingAttachment> MstTrainingAttachments { get; set; }
        public virtual ICollection<MstTrainingFeedback> MstTrainingFeedbacks { get; set; }
        public virtual ICollection<TrnsTrainingAttendanceAttachment> TrnsTrainingAttendanceAttachments { get; set; }
        public virtual ICollection<TrnsTrainingAttendance> TrnsTrainingAttendances { get; set; }
        public virtual ICollection<TrnsTrainingEvaluation> TrnsTrainingEvaluations { get; set; }
        public virtual ICollection<TrnsTrainingFeedback> TrnsTrainingFeedbacks { get; set; }
        public virtual ICollection<TrnsTrainingPlanDetail> TrnsTrainingPlanDetails { get; set; }
    }
}
