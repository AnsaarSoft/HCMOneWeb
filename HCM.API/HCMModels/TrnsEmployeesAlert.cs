using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsEmployeesAlert
    {
        public int Id { get; set; }
        public int? AlertId { get; set; }
        public int? EmpId { get; set; }
        public bool? Status { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public virtual CfgAlertManagement Alert { get; set; }
        public virtual MstEmployee Emp { get; set; }
    }
}
