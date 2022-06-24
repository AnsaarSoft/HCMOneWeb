using System;
using System.Collections.Generic;

namespace HCM.API.Models
{
    public partial class MstShiftsDetail
    {
        public int Id { get; set; }
        public int? Fkid { get; set; }
        public string Day { get; set; } = null!;
        public string StartTime { get; set; } = null!;
        public string EndTime { get; set; } = null!;
        public string Duration { get; set; } = null!;
        public bool? FlgOutOverlap { get; set; }
        public string? BufferStartTime { get; set; }
        public string? BufferEndTime { get; set; }
        public bool? FlgExpectedIn { get; set; }
        public bool? FlgExpectedOut { get; set; }
        public string? StartGraceTime { get; set; }
        public string? EndGraceTime { get; set; }
        public string? BreakTime { get; set; }

        public virtual MstShift? Fk { get; set; }
    }
}
