using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstElementDeduction
    {
        public int Id { get; set; }
        public int? ElementId { get; set; }
        public decimal? Value { get; set; }
        public string ValueType { get; set; }
        public string ValueTypeLovtype { get; set; }
        public int? FormulaBuilderId { get; set; }
        public bool? FlgMultipleEntryAllowed { get; set; }
        public bool? FlgAdditionalEntryAllowed { get; set; }
        public bool? FlgEos { get; set; }
        public bool? FlgNonTaxable { get; set; }
        public bool? FlgPropotionate { get; set; }
        public bool? FlgVariableValue { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }
        public string FormulaCode { get; set; }
        public string DeductionType { get; set; }
        public bool? FlgSlabWise { get; set; }

        public virtual MstElement Element { get; set; }
    }
}
