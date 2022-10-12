using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class CfgEmployeeShift
    {
        public int InternalId { get; set; }
        public string EmpId { get; set; }
        public string ShiftCode { get; set; }
        public bool? FlgActive { get; set; }
        public bool? FlgDefault { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
