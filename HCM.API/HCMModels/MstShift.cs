using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstShift
    {
        public MstShift()
        {
            CfgPayrollShifts = new HashSet<CfgPayrollShift>();
            MstShiftBreaks = new HashSet<MstShiftBreak>();
            MstShiftDetails = new HashSet<MstShiftDetail>();
            NeskTrnsAttendanceRegisters = new HashSet<NeskTrnsAttendanceRegister>();
            TrnsAttendanceRegisterTs = new HashSet<TrnsAttendanceRegisterT>();
            TrnsAttendanceRegisters = new HashSet<TrnsAttendanceRegister>();
            TrnsEmployeeWddetails = new HashSet<TrnsEmployeeWddetail>();
            TrnsTextileGroupAttendanceRegs = new HashSet<TrnsTextileGroupAttendanceReg>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Sstart { get; set; }
        public string Send { get; set; }
        public string Duration { get; set; }
        public bool? StatusShift { get; set; }
        public string ShiftType { get; set; }
        public string ShiftLovtype { get; set; }
        public bool? OverTime { get; set; }
        public int? OverTimeId { get; set; }
        public bool? FlgInTimeOverlap { get; set; }
        public bool? FlgOutTimeOverlap { get; set; }
        public bool? FlgOtwrkHrs { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }
        public int? DeductionRuleId { get; set; }
        public bool? FlgOffDayOverTime { get; set; }
        public int? OffDayOverTime { get; set; }
        public int? OffDaysPresentLimit { get; set; }
        public bool? FlgHoliDayOverTime { get; set; }
        public int? HoliDayOverTime { get; set; }
        public bool? FlgWorkingHoursOnMultipTimeInTimeOut { get; set; }
        public bool? FlgLeaveDeductionOnWorkingHours { get; set; }
        public string Classification { get; set; }
        public bool? FlgActive { get; set; }
        public bool? FlgOverTime { get; set; }

        public virtual ICollection<CfgPayrollShift> CfgPayrollShifts { get; set; }
        public virtual ICollection<MstShiftBreak> MstShiftBreaks { get; set; }
        public virtual ICollection<MstShiftDetail> MstShiftDetails { get; set; }
        public virtual ICollection<NeskTrnsAttendanceRegister> NeskTrnsAttendanceRegisters { get; set; }
        public virtual ICollection<TrnsAttendanceRegisterT> TrnsAttendanceRegisterTs { get; set; }
        public virtual ICollection<TrnsAttendanceRegister> TrnsAttendanceRegisters { get; set; }
        public virtual ICollection<TrnsEmployeeWddetail> TrnsEmployeeWddetails { get; set; }
        public virtual ICollection<TrnsTextileGroupAttendanceReg> TrnsTextileGroupAttendanceRegs { get; set; }
    }
}
