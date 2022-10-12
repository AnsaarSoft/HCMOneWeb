using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class CfgAlertManagementGroup
    {
        public int Id { get; set; }
        public int? Amid { get; set; }
        public int? GroupCode { get; set; }
        public string GroupName { get; set; }
        public bool? FlgNotification { get; set; }
        public bool? FlgEmail { get; set; }

        public virtual CfgAlertManagement Am { get; set; }
        public virtual MstAlertGroup GroupCodeNavigation { get; set; }
    }
}
