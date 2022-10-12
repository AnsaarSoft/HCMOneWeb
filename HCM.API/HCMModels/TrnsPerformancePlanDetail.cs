using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsPerformancePlanDetail
    {
        public int Id { get; set; }
        public int? Ppid { get; set; }
        public int? Kpiid { get; set; }
        public decimal? WeightagePer { get; set; }
        public decimal? TargetPer { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }

        public virtual TrnsKpi Kpi { get; set; }
        public virtual TrnsPerformancePlan Pp { get; set; }
    }
}
