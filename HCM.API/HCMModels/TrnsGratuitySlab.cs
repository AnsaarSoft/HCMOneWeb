using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsGratuitySlab
    {
        public TrnsGratuitySlab()
        {
            MstEmployees = new HashSet<MstEmployee>();
            TrnsGratuitySlabsDetails = new HashSet<TrnsGratuitySlabsDetail>();
        }

        public int InternalId { get; set; }
        public string SlabCode { get; set; }
        public string BasedOn { get; set; }
        public decimal? BasedOnValue { get; set; }
        public decimal? CalculatedDays { get; set; }
        public bool? FlgWopleaves { get; set; }
        public bool? FlgAbsoluteYears { get; set; }
        public bool? FlgEffectiveDate { get; set; }
        public bool? FlgPerYear { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public virtual ICollection<MstEmployee> MstEmployees { get; set; }
        public virtual ICollection<TrnsGratuitySlabsDetail> TrnsGratuitySlabsDetails { get; set; }
    }
}
