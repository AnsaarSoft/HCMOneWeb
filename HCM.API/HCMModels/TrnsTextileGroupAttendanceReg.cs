using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsTextileGroupAttendanceReg
    {
        public int Id { get; set; }
        public int? EmpId { get; set; }
        public int? PeriodId { get; set; }
        public DateTime? Date { get; set; }
        public string DayName { get; set; }
        public int? ShiftId { get; set; }
        public string ShiftHours { get; set; }
        public bool? FlgOffDay { get; set; }
        public string TimeIn { get; set; }
        public string TimeOut { get; set; }
        public string WorkHours { get; set; }
        public bool? FlgOnLeave { get; set; }
        public bool? FlgOnAbsent { get; set; }
        public string LateInMin { get; set; }
        public string EarlyOutMin { get; set; }
        public decimal? Otcount { get; set; }
        public decimal? LeaveCount { get; set; }
        public bool? FlgProcessed { get; set; }
        public bool? FlgPosted { get; set; }
        public string ProcessedBy { get; set; }
        public string PostedBy { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Othours { get; set; }

        public virtual MstEmployee Emp { get; set; }
        public virtual CfgPeriodDate Period { get; set; }
        public virtual MstShift Shift { get; set; }
    }
}
