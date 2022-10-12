using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class CfgApprovalTemplate
    {
        public CfgApprovalTemplate()
        {
            CfgApprovalTemplateDocuments = new HashSet<CfgApprovalTemplateDocument>();
            CfgApprovalTemplateOriginators = new HashSet<CfgApprovalTemplateOriginator>();
            CfgApprovalTemplateStages = new HashSet<CfgApprovalTemplateStage>();
            CfgDocumentStageRegisters = new HashSet<CfgDocumentStageRegister>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? FlgActive { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }

        public virtual ICollection<CfgApprovalTemplateDocument> CfgApprovalTemplateDocuments { get; set; }
        public virtual ICollection<CfgApprovalTemplateOriginator> CfgApprovalTemplateOriginators { get; set; }
        public virtual ICollection<CfgApprovalTemplateStage> CfgApprovalTemplateStages { get; set; }
        public virtual ICollection<CfgDocumentStageRegister> CfgDocumentStageRegisters { get; set; }
    }
}
