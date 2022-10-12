using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsMarriageAssistanceRequest
    {
        public int Id { get; set; }
        public int? EmpId { get; set; }
        public string AssistanceType { get; set; }
        public string MeetRequirement { get; set; }
        public string Remarks { get; set; }
        public int? ProposedAmount { get; set; }
        public string ApprovalOfDoc { get; set; }
        public string ApprovalReceivingApp { get; set; }
        public string Attachment { get; set; }
        public int? DocNum { get; set; }
        public byte? DocType { get; set; }
        public string DocStatus { get; set; }
        public string DocAprStatus { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string AttachmentType { get; set; }
        public DateTime? ZakaatEmpDate { get; set; }

        public virtual MstEmployee Emp { get; set; }
    }
}
