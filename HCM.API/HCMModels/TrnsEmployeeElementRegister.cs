using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsEmployeeElementRegister
    {
        public TrnsEmployeeElementRegister()
        {
            TrnsEmployeeElementRegisterDetails = new HashSet<TrnsEmployeeElementRegisterDetail>();
        }

        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public int? PayrollId { get; set; }
        public int? PperiodId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }

        public virtual MstEmployee Employee { get; set; }
        public virtual CfgPayrollDefination Payroll { get; set; }
        public virtual CfgPeriodDate Pperiod { get; set; }
        public virtual ICollection<TrnsEmployeeElementRegisterDetail> TrnsEmployeeElementRegisterDetails { get; set; }
    }
}
