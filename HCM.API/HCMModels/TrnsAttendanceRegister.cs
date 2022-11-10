using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsAttendanceRegister
    {
        public TrnsAttendanceRegister()
        {
            TrnsAttendanceRegisterDetails = new HashSet<TrnsAttendanceRegisterDetail>();
        }

        public int Id { get; set; }
        public int? EmpId { get; set; }
        public int FkpayrollId { get; set; }
        public int? PeriodId { get; set; }
        public DateTime? Date { get; set; }
        public string DateDay { get; set; }
        public string TimeIn { get; set; }
        public string TimeOut { get; set; }
        public string WorkHour { get; set; }
        public int? Ottype { get; set; }
        public string Othour { get; set; }
        public int? LeaveType { get; set; }
        public string LeaveHour { get; set; }
        public int? ShiftId { get; set; }
        public int? ShiftIdnew { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }
        public bool? Processed { get; set; }
        public string LateInMin { get; set; }
        public string EarlyOutMin { get; set; }
        public string EarlyInMin { get; set; }
        public string LateOutMin { get; set; }
        public bool? FlgPosted { get; set; }
        public int? CalculatedUnits { get; set; }
        public int? ManualUnits { get; set; }
        public int? Otunits { get; set; }
        public bool? FlgIsNewLeave { get; set; }
        public string LeaveDedRule { get; set; }
        public string Description { get; set; }
        public decimal? LeaveCount { get; set; }
        public bool? FlgSave { get; set; }
        public bool? FlgPost { get; set; }
        public bool? FlgOffDay { get; set; }
        public bool? FlgModified { get; set; }
        public string PreTimeIn { get; set; }
        public string PreTimeOut { get; set; }
        public string Remarks { get; set; }
        public string TourHours { get; set; }
        public string TotalWorkingHours { get; set; }
        public string OvertimeAdjustment { get; set; }
        public string StandardPaidHours { get; set; }
        public string ReportingTime { get; set; }
        public DateTime? Date2 { get; set; }
        public DateTime? Time { get; set; }
        public string Field1 { get; set; }
        public string Field2 { get; set; }
        public string ShortHours { get; set; }
        public bool? FlgMtpenalty { get; set; }
        public bool? FlgProcessed { get; set; }

        public virtual MstEmployee Emp { get; set; }
        public virtual MstLeaveType LeaveTypeNavigation { get; set; }
        public virtual MstOverTime OttypeNavigation { get; set; }
        public virtual CfgPeriodDate Period { get; set; }
        public virtual ICollection<TrnsAttendanceRegisterDetail> TrnsAttendanceRegisterDetails { get; set; }
    }
}
