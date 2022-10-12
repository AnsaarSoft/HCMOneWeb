using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstAttendanceRule
    {
        public int Id { get; set; }
        public string GpAfterTimeEnd { get; set; }
        public string GpAfterStartTime { get; set; }
        public string GpBeforeTimeEnd { get; set; }
        public string GpBeforeStartTime { get; set; }
        public bool FlgGpActive { get; set; }
        public bool FlgEarlyIn { get; set; }
        public bool FlgEarlyOut { get; set; }
        public bool FlgLateIn { get; set; }
        public bool FlgLateOut { get; set; }
        public bool FlgEarlyInOt { get; set; }
        public bool FlgOvertime { get; set; }
        public bool? FlgConsecutiveLeave { get; set; }
        public bool? FlgWopoverFlow { get; set; }
        public bool? FlgLateInTriger { get; set; }
        public int? LateInCountTriger { get; set; }
        public string LeaveTypeWop { get; set; }
        public string LateInCountLeaveType { get; set; }
        public bool? FlgShortLeave { get; set; }
        public decimal? ShortLeaveCount { get; set; }
        public bool? FlgTimeBaseDeductionRules { get; set; }
        public bool? FlgSandwichLeaves { get; set; }
        public bool? FlgMissingTimePenalty { get; set; }
        public int? MissingTimePanaltyCounter { get; set; }
        public string MptleaveType { get; set; }
        public bool? FlgDeductGpAfterTimeEnd { get; set; }
        public bool? FlgDeductGpAfterStartTime { get; set; }
        public bool? FlgDeductGpBeforeTimeEnd { get; set; }
        public bool? FlgDeductGpBeforeStartTime { get; set; }
        public string SandwichLeaveType { get; set; }
        public string DefaultLeaveType { get; set; }
        public bool? FlgSandwichLeavesDoubleSide { get; set; }
        public bool? FlgSandwichLeavesSingleSide { get; set; }
    }
}
