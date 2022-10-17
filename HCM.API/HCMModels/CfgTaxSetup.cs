using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class CfgTaxSetup
    {
        public CfgTaxSetup()
        {
            CfgTaxDetails = new HashSet<CfgTaxDetail>();
        }

        public int Id { get; set; }
        public int? SalaryYear { get; set; }
        public decimal? MinTaxSalaryF { get; set; }
        public int? SeniorCitizonAge { get; set; }
        public decimal? MaxSalaryDisc { get; set; }
        public decimal? DiscountOnTotalTax { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }

        public virtual MstCalendar SalaryYearNavigation { get; set; }
        public virtual ICollection<CfgTaxDetail> CfgTaxDetails { get; set; }
    }
}
