using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class NeskTrnsAttendanceRegister
    {
        public int Id { get; set; }
        public int? EmpId { get; set; }
        public int? PeriodId { get; set; }
        public DateTime? Date { get; set; }
        public string TimeInFst { get; set; }
        public string TimeOutFst { get; set; }
        public string TimeInSecond { get; set; }
        public string TimeOutSecond { get; set; }
        public string WorkHour { get; set; }
        public decimal? AdjDays { get; set; }
        public decimal? AdjHrs { get; set; }
        public decimal? HrsRate { get; set; }
        public int? ShiftId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }
        public bool? Processed { get; set; }
        public string LateInMin { get; set; }
        public string EarlyOutMin { get; set; }
        public string EarlyInMin { get; set; }
        public string LateOutMin { get; set; }

        public virtual MstShift Shift { get; set; }
    }
}
