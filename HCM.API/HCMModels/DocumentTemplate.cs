using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class DocumentTemplate
    {
        public DocumentTemplate()
        {
            ApprovalDecisionRegisters = new HashSet<ApprovalDecisionRegister>();
            DocumentTemplateDetails = new HashSet<DocumentTemplateDetail>();
        }

        public int Id { get; set; }
        public int? DocType { get; set; }
        public string DocDesc { get; set; }
        public int? DepartId { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool? FlgFollowHierarchy { get; set; }
        public int? LocationId { get; set; }

        public virtual ICollection<ApprovalDecisionRegister> ApprovalDecisionRegisters { get; set; }
        public virtual ICollection<DocumentTemplateDetail> DocumentTemplateDetails { get; set; }
    }
}
