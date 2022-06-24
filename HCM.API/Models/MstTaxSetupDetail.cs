using System;
using System.Collections.Generic;

namespace HCM.API.Models
{
    public partial class MstTaxSetupDetail
    {
        public int Id { get; set; }
        public int? Fkid { get; set; }
        public string TaxCode { get; set; } = null!;
        public decimal MinAmount { get; set; }
        public decimal MaxAmount { get; set; }
        public decimal? TaxValue { get; set; }
        public decimal? FixTerm { get; set; }
        public string? Description { get; set; }
        public bool? FlgActive { get; set; }
        public decimal? AdditionalDisc { get; set; }

        public virtual MstTaxSetup? Fk { get; set; }
    }
}
