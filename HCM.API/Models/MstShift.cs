using System;
using System.Collections.Generic;

namespace HCM.API.Models
{
    public partial class MstShift
    {
        public MstShift()
        {
            MstShiftsDetails = new HashSet<MstShiftsDetail>();
        }

        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool? FlgOverTime { get; set; }
        public int? OverTimeId { get; set; }
        public bool? FlgOtwrkHrs { get; set; }
        public int? DeductionRuleId { get; set; }
        public bool? FlgOffDayOverTime { get; set; }
        public int? OffDayOverTime { get; set; }
        public bool? FlgHoliDayOverTime { get; set; }
        public int? HoliDayOverTime { get; set; }
        public bool? FlgActive { get; set; }

        public virtual ICollection<MstShiftsDetail> MstShiftsDetails { get; set; }
    }
}
