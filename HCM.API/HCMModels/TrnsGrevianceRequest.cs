using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsGrevianceRequest
    {
        public int Id { get; set; }
        public int? AggrievedEmployee { get; set; }
        public int? ComplaintAgainstEmployee { get; set; }
        public DateTime? DateOfReport { get; set; }
        public int? TypeOfGrievance { get; set; }
        public string Description { get; set; }
        public string Attachment { get; set; }
        public string AttachmentExt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string DocStatus { get; set; }
        public string DocAprStatus { get; set; }
        public int? DocType { get; set; }
        public int? DocNum { get; set; }
        public bool? FlgInquiryOfficerAssigned { get; set; }
        public bool? FlgInquiryOfficerSubmitted { get; set; }
        public int? EnquiryOfficer { get; set; }
        public string EnquiryOfficersSummary { get; set; }
        public DateTime? EnquiryOfficerSubmitDate { get; set; }
        public bool? FlgCeoApproved { get; set; }
        public bool? FlgBehalfOfCeoApproved { get; set; }
        public bool? FlgCloseWithoutCommittee { get; set; }
        public bool? FlgCloseWithCommittee { get; set; }
        public int? BehalfOfCeoEmployee { get; set; }
        public int? CommitteHead { get; set; }
        public bool? FlgCommitteeAssigned { get; set; }
        public bool? FlgCommitteeSigned { get; set; }
        public string CommitteeRemarks { get; set; }
        public bool? FlgNoFurthurAction { get; set; }
        public bool? FlgMediation { get; set; }
        public bool? FlgDisciplinaryAction { get; set; }
        public DateTime? EnquiryOfficerAssignedDate { get; set; }
        public DateTime? CommitteeFormationDate { get; set; }
        public DateTime? ComitteeSubmitReport { get; set; }
        public DateTime? HrActionDate { get; set; }
        public string RemarksofCeo { get; set; }
    }
}
