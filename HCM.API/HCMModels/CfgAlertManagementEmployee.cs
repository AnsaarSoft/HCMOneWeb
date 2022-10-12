using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class CfgAlertManagementEmployee
    {
        public int Id { get; set; }
        public int? Amid { get; set; }
        public int? EmpId { get; set; }
        public string EmpName { get; set; }
        public bool? FlgNotification { get; set; }
        public bool? FlgEmail { get; set; }
        public string FlgActive { get; set; }

        public virtual CfgAlertManagement Am { get; set; }
        public virtual MstEmployee Emp { get; set; }
    }
}
