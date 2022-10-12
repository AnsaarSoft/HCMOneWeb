using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstBonusYearly
    {
        public int Id { get; set; }
        public int? DocNo { get; set; }
        public string DocCode { get; set; }
        public string Code { get; set; }
        public string ValueType { get; set; }
        public decimal? SalaryFrom { get; set; }
        public decimal? SalaryTo { get; set; }
        public int? ScaleFrom { get; set; }
        public int? ScaleTo { get; set; }
        public decimal? BonusPercentage { get; set; }
        public decimal? MinimumMonthsDuration { get; set; }
        public int? ElementType { get; set; }
        public bool? FlgActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
