using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class AttSummaryDetail
    {
        public long AttSumDetailId { get; set; }
        public long? AttSummaryId { get; set; }
        public int? EmpId { get; set; }
        public string EmpCode { get; set; }
        public string EmpName { get; set; }
        public decimal? AdjDays { get; set; }
        public decimal? AdjHrs { get; set; }
        public decimal? HrsRate { get; set; }
        public bool? FlgActive { get; set; }
        public string Remarks { get; set; }
        public string SourceType { get; set; }
        public long? SourceId { get; set; }

        public virtual AttSummary AttSummary { get; set; }
        public virtual MstEmployee Emp { get; set; }
    }
}
