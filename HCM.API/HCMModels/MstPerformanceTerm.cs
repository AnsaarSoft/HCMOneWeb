using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstPerformanceTerm
    {
        public MstPerformanceTerm()
        {
            PerformanceStatementTermAttachments = new HashSet<PerformanceStatementTermAttachment>();
            TrnsPerformanceEvaluationHeads = new HashSet<TrnsPerformanceEvaluationHead>();
        }

        public int Id { get; set; }
        public string YearId { get; set; }
        public string TermDescription { get; set; }
        public int? Weightage { get; set; }
        public bool? FlgIncrement { get; set; }
        public int? IncrementPercentage { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool? FlgActive { get; set; }
        public DateTime? AvailableForEvaluation { get; set; }
        public DateTime? CloseDate { get; set; }
        public int? NotificationDaysForAppraise { get; set; }
        public int? NotificationDaysForAppraiser { get; set; }
        public bool? FlgPerformanceBonus { get; set; }
        public bool? FlgCommitmentAllowance { get; set; }

        public virtual MstCalendar Year { get; set; }
        public virtual ICollection<PerformanceStatementTermAttachment> PerformanceStatementTermAttachments { get; set; }
        public virtual ICollection<TrnsPerformanceEvaluationHead> TrnsPerformanceEvaluationHeads { get; set; }
    }
}
