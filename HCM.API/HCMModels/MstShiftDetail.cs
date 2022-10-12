using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstShiftDetail
    {
        public int Id { get; set; }
        public int? ShiftId { get; set; }
        public string Day { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Duration { get; set; }
        public bool? FlgInOverlap { get; set; }
        public bool? FlgOutOverlap { get; set; }
        public string BufferStartTime { get; set; }
        public string BufferEndTime { get; set; }
        public int? SeqNum { get; set; }
        public bool? FlgExpectedIn { get; set; }
        public bool? FlgExpectedOut { get; set; }
        public string LunchHours { get; set; }
        public string StartGraceTime { get; set; }
        public string EndGraceTime { get; set; }
        public string BreakTime { get; set; }
        public string ApplicableTime { get; set; }

        public virtual MstShift Shift { get; set; }
    }
}
