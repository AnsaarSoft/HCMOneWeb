using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsEmployeeWorkDay
    {
        public TrnsEmployeeWorkDay()
        {
            TrnsEmployeeWddetails = new HashSet<TrnsEmployeeWddetail>();
        }

        public int Id { get; set; }
        public int? PayrollId { get; set; }
        public int? PayrollPeriodId { get; set; }
        public int? LocationId { get; set; }
        public int? DepartmentId { get; set; }
        public int? EmployeeIdfrom { get; set; }
        public int? EmployeeIdto { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdateBy { get; set; }

        public virtual MstLocation Location { get; set; }
        public virtual CfgPayrollDefination Payroll { get; set; }
        public virtual CfgPeriodDate PayrollPeriod { get; set; }
        public virtual ICollection<TrnsEmployeeWddetail> TrnsEmployeeWddetails { get; set; }
    }
}
