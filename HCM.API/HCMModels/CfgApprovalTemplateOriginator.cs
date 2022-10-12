using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class CfgApprovalTemplateOriginator
    {
        public int Id { get; set; }
        public int? Atid { get; set; }
        public int? Originator { get; set; }

        public virtual CfgApprovalTemplate At { get; set; }
    }
}
