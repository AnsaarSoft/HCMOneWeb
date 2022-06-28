using System;
using System.Collections.Generic;

namespace HCM.API.Models
{
    public partial class VMMstBonusDetail
    {
        public int Id { get; set; }
        public int DocNo { get; set; }
        public string? DocCode { get; set; }
        public string? Code { get; set; }
        public string? ValueType { get; set; }
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
