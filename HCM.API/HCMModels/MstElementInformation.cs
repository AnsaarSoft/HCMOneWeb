using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstElementInformation
    {
        public int Id { get; set; }
        public int? ElementId { get; set; }
        public bool? FlgTaxable { get; set; }
        public decimal? Value { get; set; }
        public string TaxableIncome { get; set; }
        public string TaxableIncomeLovtype { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }

        public virtual MstElement Element { get; set; }
    }
}
