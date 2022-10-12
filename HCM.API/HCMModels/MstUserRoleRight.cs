using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstUserRoleRight
    {
        public string RoleCode { get; set; }
        public int MenuId { get; set; }
        public string Anthorization { get; set; }
    }
}
