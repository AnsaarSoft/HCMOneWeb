using System;
using System.Collections.Generic;

namespace HCM.API.Models
{
    public partial class MstOverTime
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string ValueType { get; set; }
        public decimal? Value { get; set; }
        public decimal? Hours { get; set; }
        public decimal? MonthDays { get; set; }
        public bool? FlgDefault { get; set; }
        public bool? FlgFormula { get; set; }
        public string Expression { get; set; }
        public decimal? PerDayCap { get; set; }
        public decimal? PerMonthCap { get; set; }
        public bool? FlgActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
