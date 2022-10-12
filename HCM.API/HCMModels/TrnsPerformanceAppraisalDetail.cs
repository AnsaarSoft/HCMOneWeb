using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsPerformanceAppraisalDetail
    {
        public int Id { get; set; }
        public int? Paid { get; set; }
        public int? Kpiid { get; set; }
        public string SelfAppraisal { get; set; }
        public string SelfAppraisalLov { get; set; }
        public string SelfRemarks { get; set; }
        public decimal? Weightage { get; set; }
        public decimal? TargetPer { get; set; }
        public string ReportingManager { get; set; }
        public string ReportingManagerLov { get; set; }
        public string ManagerRemarks { get; set; }
        public string Score { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }

        public virtual TrnsKpi Kpi { get; set; }
        public virtual TrnsPerformanceAppraisal Pa { get; set; }
    }
}
