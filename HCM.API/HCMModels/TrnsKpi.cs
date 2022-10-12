using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsKpi
    {
        public TrnsKpi()
        {
            TrnsPerformanceAppraisalDetails = new HashSet<TrnsPerformanceAppraisalDetail>();
            TrnsPerformancePlanDetails = new HashSet<TrnsPerformancePlanDetail>();
        }

        public int Id { get; set; }
        public string KeyObjectives { get; set; }
        public string LaggingKpi { get; set; }
        public string LeadingKpi { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }

        public virtual ICollection<TrnsPerformanceAppraisalDetail> TrnsPerformanceAppraisalDetails { get; set; }
        public virtual ICollection<TrnsPerformancePlanDetail> TrnsPerformancePlanDetails { get; set; }
    }
}
