using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsQuarterTaxAdj
    {
        public TrnsQuarterTaxAdj()
        {
            TrnsQuarterTaxAdjDetails = new HashSet<TrnsQuarterTaxAdjDetail>();
        }

        public int Id { get; set; }
        public int? EmpId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreateDt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdateDt { get; set; }

        public virtual ICollection<TrnsQuarterTaxAdjDetail> TrnsQuarterTaxAdjDetails { get; set; }
    }
}
