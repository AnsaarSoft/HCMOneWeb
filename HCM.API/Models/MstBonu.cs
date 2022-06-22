using System;
using System.Collections.Generic;

namespace HCM.API.Models
{
    public partial class MstBonu
    {
        public int Id { get; set; }
        public int DocNo { get; set; }
        public string DocCode { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string ValueType { get; set; } = null!;
        public decimal SalaryFrom { get; set; }
        public decimal SalaryTo { get; set; }
        public int ScaleFrom { get; set; }
        public int ScaleTo { get; set; }
        public decimal BonusPercentage { get; set; }
        public decimal MinimumMonthsDuration { get; set; }
        public int? ElementType { get; set; }
        public bool FlgActive { get; set; }
    }
}
