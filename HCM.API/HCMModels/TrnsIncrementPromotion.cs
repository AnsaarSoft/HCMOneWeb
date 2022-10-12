using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsIncrementPromotion
    {
        public TrnsIncrementPromotion()
        {
            TrnsIncDetails = new HashSet<TrnsIncDetail>();
        }

        public int Id { get; set; }
        public int? PayrollId { get; set; }
        public decimal? IncreamentValue { get; set; }
        public string IncreamentType { get; set; }
        public DateTime? ApplicableDate { get; set; }
        public int? ApplyOn { get; set; }
        public int? PayIn { get; set; }
        public int? ArearElementId { get; set; }
        public int? StatusRec { get; set; }
        public long? TransId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }

        public virtual CfgPayrollDefination Payroll { get; set; }
        public virtual ICollection<TrnsIncDetail> TrnsIncDetails { get; set; }
    }
}
