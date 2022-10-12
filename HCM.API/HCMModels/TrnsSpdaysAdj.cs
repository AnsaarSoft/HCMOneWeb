using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsSpdaysAdj
    {
        public long Id { get; set; }
        public int? EmpId { get; set; }
        public int? PeriodId { get; set; }
        public decimal? OverTiimeHrsCount { get; set; }
        public string OverTimeCode { get; set; }
        public decimal? AdjDaysCount { get; set; }
        public decimal? AdjHourCount { get; set; }
        public string AdjType { get; set; }
        public string Remarks { get; set; }
        public bool? FlgActive { get; set; }
        public long? ProcessingId { get; set; }
        public decimal? DeductedAmount { get; set; }
        public DateTime? CreateDt { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string CreateBy { get; set; }
        public string UpdateBy { get; set; }

        public virtual MstEmployee Emp { get; set; }
        public virtual CfgPeriodDate Period { get; set; }
    }
}
