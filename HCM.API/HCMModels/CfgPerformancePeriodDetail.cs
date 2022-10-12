using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class CfgPerformancePeriodDetail
    {
        public int Id { get; set; }
        public int? Ppcid { get; set; }
        public int? PlanNo { get; set; }
        public DateTime? PlanDate { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string Branch { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }

        public virtual TrnsPerformancePlan PlanNoNavigation { get; set; }
        public virtual CfgPerformancePeriod Ppc { get; set; }
    }
}
