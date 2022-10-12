using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsAttendanceRegisterT
    {
        public int Id { get; set; }
        public int? EmpId { get; set; }
        public int? PeriodId { get; set; }
        public DateTime? Date { get; set; }
        public string DayName { get; set; }
        public int? ShiftId { get; set; }
        public string ShiftHours { get; set; }
        public string TimeIn { get; set; }
        public string TimeOut { get; set; }
        public decimal? Otcount { get; set; }
        public string Othours { get; set; }
        public string WorkHours { get; set; }
        public bool? OnLeave { get; set; }
        public bool? FlgOffDay { get; set; }
        public bool? FlgOnSpecialDayLeave { get; set; }
        public bool? OnAbsent { get; set; }
        public string LateInMin { get; set; }
        public bool? Processed { get; set; }
        public bool? Posted { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string ProcessedBy { get; set; }
        public string PostedBy { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string EarlyOutMin { get; set; }

        public virtual MstEmployee Emp { get; set; }
        public virtual MstShift Shift { get; set; }
    }
}
