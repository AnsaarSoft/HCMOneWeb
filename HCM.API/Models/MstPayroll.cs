using System;
using System.Collections.Generic;

namespace HCM.API.Models
{
    public partial class MstPayroll
    {
        public MstPayroll()
        {
            MstPayrollElements = new HashSet<MstPayrollElement>();
            MstPayrollPeriods = new HashSet<MstPayrollPeriod>();
        }

        public int Id { get; set; }
        public string PayrollName { get; set; }
        public string PayrollType { get; set; }
        public DateTime? FirstPeriodEndDt { get; set; }
        public short? WorkDays { get; set; }
        public decimal? WorkHours { get; set; }
        public string Gltype { get; set; }
        public bool? FlgOffDaysExcludedFromSalaryPeriod { get; set; }
        public bool? FlgActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<MstPayrollElement> MstPayrollElements { get; set; }
        public virtual ICollection<MstPayrollPeriod> MstPayrollPeriods { get; set; }
    }
}
