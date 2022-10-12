using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsAssistanceRequest
    {
        public int Id { get; set; }
        public int? EmpId { get; set; }
        public int? FileType { get; set; }
        public string ProblemType { get; set; }
        public string MaritalStatus { get; set; }
        public int? TotalFees { get; set; }
        public int? DueFees { get; set; }
        public int? TotalRent { get; set; }
        public int? DueRent { get; set; }
        public int? TotalLoan { get; set; }
        public int? DueAmount { get; set; }
        public int? InstallmentLoan { get; set; }
        public DateTime? Date { get; set; }
        public string Reason { get; set; }
        public string Attachment { get; set; }
        public string AttachmentType { get; set; }
        public int? DocNum { get; set; }
        public byte? DocType { get; set; }
        public string DocStatus { get; set; }
        public string DocAprStatus { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string OtherReason { get; set; }
        public string OtherMartialStatus { get; set; }
        public string Remarks { get; set; }

        public virtual MstEmployee Emp { get; set; }
    }
}
