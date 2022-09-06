using System;
using System.Collections.Generic;

namespace HCM.API.Models
{
    public partial class MstTaxSetup
    {
        public MstTaxSetup()
        {
            MstTaxSetupDetails = new HashSet<MstTaxSetupDetail>();
        }

        public int Id { get; set; }
        public int? SalaryYear { get; set; }
        public decimal? MinTaxSalaryF { get; set; }
        public short? SeniorCitizonAge { get; set; }
        public decimal? MaxSalaryDisc { get; set; }
        public decimal? DiscountOnTotalTax { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<MstTaxSetupDetail> MstTaxSetupDetails { get; set; }
    }
}
