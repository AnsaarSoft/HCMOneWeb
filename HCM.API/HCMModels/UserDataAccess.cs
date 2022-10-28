using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class UserDataAccess
    {
        public int Id { get; set; }
        public string EmpId { get; set; }
        public int? FkEmpId { get; set; }
        public int? FkPayrollId { get; set; }
        public string PayrollName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool? FlgActive { get; set; }

        public virtual CfgPayrollDefination FkPayroll { get; set; }
    }
}
