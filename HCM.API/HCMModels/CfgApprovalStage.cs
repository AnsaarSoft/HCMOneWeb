using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class CfgApprovalStage
    {
        public CfgApprovalStage()
        {
            CfgApprovalStageDetails = new HashSet<CfgApprovalStageDetail>();
            CfgApprovalTemplateStages = new HashSet<CfgApprovalTemplateStage>();
            CfgDocumentStageRegisters = new HashSet<CfgDocumentStageRegister>();
        }

        public int Id { get; set; }
        public string StageName { get; set; }
        public string StageDescription { get; set; }
        public byte ApprovalsNo { get; set; }
        public byte RejectionsNo { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool? FlgActive { get; set; }

        public virtual ICollection<CfgApprovalStageDetail> CfgApprovalStageDetails { get; set; }
        public virtual ICollection<CfgApprovalTemplateStage> CfgApprovalTemplateStages { get; set; }
        public virtual ICollection<CfgDocumentStageRegister> CfgDocumentStageRegisters { get; set; }
    }
}
