using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class CfgTaxDetail
    {
        public int Id { get; set; }
        public int? Pid { get; set; }
        public string TaxCode { get; set; }
        public decimal? MinAmount { get; set; }
        public decimal? MaxAmount { get; set; }
        public decimal? TaxValue { get; set; }
        public decimal? FixTerm { get; set; }
        public string Description { get; set; }
        public bool? FlgActive { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }
        public decimal? AdditionalDisc { get; set; }

        public virtual CfgTaxSetup PidNavigation { get; set; }
    }
}
