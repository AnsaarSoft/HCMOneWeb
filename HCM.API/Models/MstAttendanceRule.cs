using System;
using System.Collections.Generic;

namespace HCM.API.Models
{
    public partial class MstAttendanceRule
    {
        public int Id { get; set; }
        public bool FlgGpActive { get; set; }
        public string? GpAfterTimeEnd { get; set; }
        public string? GpAfterStartTime { get; set; }
        public string? GpBeforeTimeEnd { get; set; }
        public string? GpBeforeStartTime { get; set; }
        public bool? FlgDeductGpAfterTimeEnd { get; set; }
        public bool? FlgDeductGpAfterStartTime { get; set; }
        public bool? FlgDeductGpBeforeTimeEnd { get; set; }
        public bool? FlgDeductGpBeforeStartTime { get; set; }
        public bool FlgLateIn { get; set; }
        public bool FlgEarlyOut { get; set; }
        public bool? FlgSandwichLeavesDoubleSide { get; set; }
        public bool? FlgSandwichLeavesSingleSide { get; set; }
        public string? DefaultLeaveType { get; set; }
    }
}
