using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class CfgDocumentStageRegister
    {
        public int Id { get; set; }
        public int? DocNum { get; set; }
        public byte? DocType { get; set; }
        public int? Series { get; set; }
        public int? TempStages { get; set; }
        public int? ApprovalTemp { get; set; }
        public string StageDecision { get; set; }
        public bool? FlgCurrentStage { get; set; }

        public virtual CfgApprovalTemplate ApprovalTempNavigation { get; set; }
        public virtual CfgApprovalStage TempStagesNavigation { get; set; }
    }
}
