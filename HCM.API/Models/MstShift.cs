using System;
using System.Collections.Generic;

namespace HCM.API.Models
{
    public partial class MstShift
    {
        public MstShift()
        {
            MstShiftsDetails = new HashSet<MstShiftsDetail>();
            TrnsAttendanceRegisters = new HashSet<TrnsAttendanceRegister>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool? FlgOverTime { get; set; }
        public int? OverTimeId { get; set; }
        public bool? FlgOtwrkHrs { get; set; }
        public int? DeductionRuleId { get; set; }
        public bool? FlgOffDayOverTime { get; set; }
        public int? OffDayOverTime { get; set; }
        public bool? FlgHoliDayOverTime { get; set; }
        public int? HoliDayOverTime { get; set; }
        public bool? FlgActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<MstShiftsDetail> MstShiftsDetails { get; set; }
        public virtual ICollection<TrnsAttendanceRegister> TrnsAttendanceRegisters { get; set; }
    }
}
