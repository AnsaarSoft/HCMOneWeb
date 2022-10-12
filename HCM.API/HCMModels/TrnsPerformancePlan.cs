using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsPerformancePlan
    {
        public TrnsPerformancePlan()
        {
            CfgPerformancePeriodDetails = new HashSet<CfgPerformancePeriodDetail>();
            TrnsPerformanceAppraisal360s = new HashSet<TrnsPerformanceAppraisal360>();
            TrnsPerformanceAppraisals = new HashSet<TrnsPerformanceAppraisal>();
            TrnsPerformancePlanDetails = new HashSet<TrnsPerformancePlanDetail>();
            TrnsPromotionAdvices = new HashSet<TrnsPromotionAdvice>();
        }

        public int Id { get; set; }
        public bool? PlanStatus { get; set; }
        public int? PlanNo { get; set; }
        public DateTime? PlanDate { get; set; }
        public int? EmpId { get; set; }
        public string EmpDesignation { get; set; }
        public string EmpDepartment { get; set; }
        public string EmpBranch { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }

        public virtual MstEmployee Emp { get; set; }
        public virtual ICollection<CfgPerformancePeriodDetail> CfgPerformancePeriodDetails { get; set; }
        public virtual ICollection<TrnsPerformanceAppraisal360> TrnsPerformanceAppraisal360s { get; set; }
        public virtual ICollection<TrnsPerformanceAppraisal> TrnsPerformanceAppraisals { get; set; }
        public virtual ICollection<TrnsPerformancePlanDetail> TrnsPerformancePlanDetails { get; set; }
        public virtual ICollection<TrnsPromotionAdvice> TrnsPromotionAdvices { get; set; }
    }
}
