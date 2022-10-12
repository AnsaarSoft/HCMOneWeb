using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsQuarterTaxAdjDetail
    {
        public int Id { get; set; }
        public int? Qtaid { get; set; }
        public int? PayrollPeriodId { get; set; }
        public decimal? Amount { get; set; }
        public string RemaiCurnt { get; set; }
        public decimal? TaxableAmount { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreateDt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdateDt { get; set; }

        public virtual TrnsQuarterTaxAdj Qta { get; set; }
    }
}
