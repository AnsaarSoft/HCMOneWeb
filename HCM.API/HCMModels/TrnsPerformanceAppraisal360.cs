using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsPerformanceAppraisal360
    {
        public TrnsPerformanceAppraisal360()
        {
            TrnsPerformanceAppraisal360Details = new HashSet<TrnsPerformanceAppraisal360Detail>();
        }

        public int Id { get; set; }
        public int? DocNum { get; set; }
        public DateTime? DocDate { get; set; }
        public byte? DocType { get; set; }
        public int? Series { get; set; }
        public int? EmpId { get; set; }
        public string EmpFirstName { get; set; }
        public string EmpLastName { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public string Branch { get; set; }
        public int? Status { get; set; }
        public int? PlanNo { get; set; }
        public DateTime? PerfPeriodFrom { get; set; }
        public DateTime? PerfPeriodTo { get; set; }
        public int? CompetencyGroupId { get; set; }
        public int? LineManager { get; set; }
        public decimal? TotalScore { get; set; }
        public decimal? OverallRating { get; set; }
        public string DocStatus { get; set; }
        public string DocStatusLov { get; set; }
        public string Remarks { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }

        public virtual MstCompetencyGroup CompetencyGroup { get; set; }
        public virtual MstEmployee Emp { get; set; }
        public virtual TrnsPerformancePlan PlanNoNavigation { get; set; }
        public virtual ICollection<TrnsPerformanceAppraisal360Detail> TrnsPerformanceAppraisal360Details { get; set; }
    }
}
