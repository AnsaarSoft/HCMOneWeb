using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsEmployeeAttendanceAllowanceDetail
    {
        public int InternalId { get; set; }
        public int? Fkid { get; set; }
        public int? EmpId { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual MstEmployee Emp { get; set; }
        public virtual TrnsEmployeeAttendanceAllowance Fk { get; set; }
    }
}
