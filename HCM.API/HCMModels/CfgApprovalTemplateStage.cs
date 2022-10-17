using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class CfgApprovalTemplateStage
    {
        public int Id { get; set; }
        public int? Atid { get; set; }
        public int? StageId { get; set; }
        public string StageName { get; set; }
        public byte? Priorty { get; set; }

        public virtual CfgApprovalTemplate At { get; set; }
        public virtual CfgApprovalStage Stage { get; set; }
    }
}
