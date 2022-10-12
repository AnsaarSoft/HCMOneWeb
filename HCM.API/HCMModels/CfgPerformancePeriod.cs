using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class CfgPerformancePeriod
    {
        public CfgPerformancePeriod()
        {
            CfgPerformancePeriodDetails = new HashSet<CfgPerformancePeriodDetail>();
        }

        public int Id { get; set; }
        public int? EmpId { get; set; }
        public string Location { get; set; }
        public string Department { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }

        public virtual ICollection<CfgPerformancePeriodDetail> CfgPerformancePeriodDetails { get; set; }
    }
}
