using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsPromotionAdvice
    {
        public int Id { get; set; }
        public byte? DocType { get; set; }
        public int? DocNum { get; set; }
        public DateTime? DocDate { get; set; }
        public int? Series { get; set; }
        public int? EmpId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public string Branch { get; set; }
        public string AdviceStatus { get; set; }
        public string AdviceStatusLov { get; set; }
        public int? PlanNo { get; set; }
        public DateTime? PerfPeriodFrom { get; set; }
        public DateTime? PerfPeriodTo { get; set; }
        public int? AppraisalNo { get; set; }
        public DateTime? AppraisalDate { get; set; }
        public DateTime? LastPromotionDate { get; set; }
        public string NewStatus { get; set; }
        public int? NewDesignation { get; set; }
        public int? NewDepartment { get; set; }
        public int? NewLineManager { get; set; }
        public decimal? IncrementPer { get; set; }
        public bool? FltPromotion { get; set; }
        public string Remarks { get; set; }
        public decimal? TotalScorce { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }

        public virtual TrnsPerformancePlan PlanNoNavigation { get; set; }
    }
}
