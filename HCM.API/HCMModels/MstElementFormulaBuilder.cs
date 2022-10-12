using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstElementFormulaBuilder
    {
        public int Id { get; set; }
        public int? EarningElementId { get; set; }
        public bool? FlgBasicSalary { get; set; }
        public bool? FlgGeneralValue { get; set; }
        public bool? FlgGlobal { get; set; }
        public string Calculation { get; set; }
        public string CalculationLovType { get; set; }
        public string ValueType { get; set; }
        public string ValueLovType { get; set; }
        public decimal? Value { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }

        public virtual MstElementEarning EarningElement { get; set; }
    }
}
