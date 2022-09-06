using System;
using System.Collections.Generic;

namespace HCM.API.Models
{
    public partial class TrnsAttendanceRegister
    {
        public int Id { get; set; }
        public int EmpId { get; set; }
        public int PayrollId { get; set; }
        public int PeriodId { get; set; }
        public DateTime Date { get; set; }
        public string DateDay { get; set; }
        public string TimeIn { get; set; }
        public string TimeOut { get; set; }
        public string WorkHour { get; set; }
        public int? Ottype { get; set; }
        public string Othour { get; set; }
        public int? LeaveType { get; set; }
        public string LeaveHour { get; set; }
        public int ShiftId { get; set; }
        public string LateInMin { get; set; }
        public string EarlyOutMin { get; set; }
        public string EarlyInMin { get; set; }
        public string LateOutMin { get; set; }
        public bool? FlgIsNewLeave { get; set; }
        public string LeaveDedRule { get; set; }
        public string Description { get; set; }
        public decimal? LeaveCount { get; set; }
        public bool? FlgProcessed { get; set; }
        public bool? FlgPosted { get; set; }
        public bool? FlgOffDay { get; set; }
        public bool? FlgModified { get; set; }
        public string PreTimeIn { get; set; }
        public string PreTimeOut { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public virtual MstEmployee Emp { get; set; }
        public virtual MstPayrollPeriod Period { get; set; }
        public virtual MstShift Shift { get; set; }
    }
}
