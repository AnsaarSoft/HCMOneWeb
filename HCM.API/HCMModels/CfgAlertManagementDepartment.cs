using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class CfgAlertManagementDepartment
    {
        public int Id { get; set; }
        public int? Amid { get; set; }
        public int? Department { get; set; }
        public string DeptName { get; set; }
        public string FlgNotification { get; set; }
        public string FlgEmail { get; set; }
        public string FlgActive { get; set; }

        public virtual CfgAlertManagement Am { get; set; }
        public virtual MstDepartment DepartmentNavigation { get; set; }
    }
}
