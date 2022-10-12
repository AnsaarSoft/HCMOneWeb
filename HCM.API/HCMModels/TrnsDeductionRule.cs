using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsDeductionRule
    {
        public TrnsDeductionRule()
        {
            TrnsDeductionRulesDetails = new HashSet<TrnsDeductionRulesDetail>();
        }

        public int Id { get; set; }
        public int DocNo { get; set; }
        public string Code { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public virtual ICollection<TrnsDeductionRulesDetail> TrnsDeductionRulesDetails { get; set; }
    }
}
