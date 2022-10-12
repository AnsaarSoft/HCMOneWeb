using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstBonu
    {
        public MstBonu()
        {
            MstPerformanceBasedPolicies = new HashSet<MstPerformanceBasedPolicy>();
        }

        public int Id { get; set; }
        public int? DocNo { get; set; }
        public string DocCode { get; set; }
        public string Code { get; set; }
        public string ValueType { get; set; }
        public decimal? SalaryFrom { get; set; }
        public decimal? SalaryTo { get; set; }
        public int? ScaleFrom { get; set; }
        public int? ScaleTo { get; set; }
        public string Description { get; set; }
        public string ValueLovtype { get; set; }
        public decimal? Value { get; set; }
        public bool? FlgActive { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }
        public decimal? BonusPercentage { get; set; }
        public decimal? MinimumMonthsDuration { get; set; }
        public int? ElementType { get; set; }

        public virtual ICollection<MstPerformanceBasedPolicy> MstPerformanceBasedPolicies { get; set; }
    }
}
