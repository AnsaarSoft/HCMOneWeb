using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class CfgPayrollShift
    {
        public int Id { get; set; }
        public int? PayrollId { get; set; }
        public int? ShiftId { get; set; }
        public int? Priority { get; set; }
        public bool? FlgActive { get; set; }
        public bool? FlgDefault { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public virtual CfgPayrollDefination Payroll { get; set; }
        public virtual MstShift Shift { get; set; }
    }
}
