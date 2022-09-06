using System;
using System.Collections.Generic;

namespace HCM.API.Models
{
    public partial class MstGratuity
    {
        public MstGratuity()
        {
            MstGratuityDetails = new HashSet<MstGratuityDetail>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string BasedOn { get; set; }
        public decimal? BasedOnValue { get; set; }
        public bool? FlgWopleaves { get; set; }
        public bool? FlgAbsoluteYears { get; set; }
        public bool? FlgEffectiveDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual ICollection<MstGratuityDetail> MstGratuityDetails { get; set; }
    }
}
