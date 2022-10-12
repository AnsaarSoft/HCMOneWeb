using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstElementLink
    {
        public int Id { get; set; }
        public int? PayrollId { get; set; }
        public int? ElementId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }
        public bool? FlgActive { get; set; }

        public virtual MstElement Element { get; set; }
        public virtual CfgPayrollDefination Payroll { get; set; }
    }
}
