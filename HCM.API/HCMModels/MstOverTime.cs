using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstOverTime
    {
        public MstOverTime()
        {
            AttSummaries = new HashSet<AttSummary>();
            TrnsAttendanceRegisters = new HashSet<TrnsAttendanceRegister>();
            TrnsEmployeeOvertimeDetails = new HashSet<TrnsEmployeeOvertimeDetail>();
            TrnsOtslabDetails = new HashSet<TrnsOtslabDetail>();
            TrnsSingleEntryOtdetails = new HashSet<TrnsSingleEntryOtdetail>();
            TrnsSingleEntryOtrequests = new HashSet<TrnsSingleEntryOtrequest>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string ValueType { get; set; }
        public string ValueLovtype { get; set; }
        public decimal? Value { get; set; }
        public decimal? MaxHour { get; set; }
        public bool? FlgActive { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }
        public string Hours { get; set; }
        public string Days { get; set; }
        public string Weeks { get; set; }
        public bool? FlgDefault { get; set; }
        public decimal? FixValue { get; set; }
        public decimal? DaysinYear { get; set; }
        public bool? FlgFormula { get; set; }
        public string Expression { get; set; }
        public bool? FlgPerHour { get; set; }
        public decimal? PerDayCap { get; set; }
        public decimal? PerMonthCap { get; set; }
        public decimal? Hour { get; set; }
        public decimal? MonthDays { get; set; }

        public virtual ICollection<AttSummary> AttSummaries { get; set; }
        public virtual ICollection<TrnsAttendanceRegister> TrnsAttendanceRegisters { get; set; }
        public virtual ICollection<TrnsEmployeeOvertimeDetail> TrnsEmployeeOvertimeDetails { get; set; }
        public virtual ICollection<TrnsOtslabDetail> TrnsOtslabDetails { get; set; }
        public virtual ICollection<TrnsSingleEntryOtdetail> TrnsSingleEntryOtdetails { get; set; }
        public virtual ICollection<TrnsSingleEntryOtrequest> TrnsSingleEntryOtrequests { get; set; }
    }
}
