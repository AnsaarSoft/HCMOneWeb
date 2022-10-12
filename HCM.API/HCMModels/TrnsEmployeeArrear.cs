using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsEmployeeArrear
    {
        public TrnsEmployeeArrear()
        {
            TrnsEmployeeArrearsDetails = new HashSet<TrnsEmployeeArrearsDetail>();
        }

        public int Id { get; set; }
        public int? PayrollId { get; set; }
        public int? PayrollPeriodId { get; set; }
        public int? LocationId { get; set; }
        public long? DepartmentId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }

        public virtual MstLocation Location { get; set; }
        public virtual CfgPayrollDefination Payroll { get; set; }
        public virtual CfgPeriodDate PayrollPeriod { get; set; }
        public virtual ICollection<TrnsEmployeeArrearsDetail> TrnsEmployeeArrearsDetails { get; set; }
    }
}
