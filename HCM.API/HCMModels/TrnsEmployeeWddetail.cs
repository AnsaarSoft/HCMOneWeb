using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsEmployeeWddetail
    {
        public int Id { get; set; }
        public int? EmpWdid { get; set; }
        public int? EmployeeId { get; set; }
        public decimal? WorkDays { get; set; }
        public decimal? PerDayIncome { get; set; }
        public decimal? NetIncome { get; set; }
        public int? ShiftId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? ShiftHours { get; set; }
        public decimal? TotalHours { get; set; }
        public decimal? Salary { get; set; }
        public string SalaryBase { get; set; }
        public string CreatedBy { get; set; }

        public virtual TrnsEmployeeWorkDay EmpWd { get; set; }
        public virtual MstShift Shift { get; set; }
    }
}
