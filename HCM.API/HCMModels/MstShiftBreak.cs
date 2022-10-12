using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstShiftBreak
    {
        public int Id { get; set; }
        public int? ShiftId { get; set; }
        public int? SeqNum { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Duration { get; set; }

        public virtual MstShift Shift { get; set; }
    }
}
