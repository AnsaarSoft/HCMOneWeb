using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsOfferLetter
    {
        public TrnsOfferLetter()
        {
            TrnsRegionalHeadDetails = new HashSet<TrnsRegionalHeadDetail>();
        }

        public int Id { get; set; }
        public int? InterviewRecommendationId { get; set; }
        public decimal? RecommendedSalary { get; set; }
        public decimal? OfferedSalary { get; set; }
        public int? EmpId { get; set; }
        public int? DesignationId { get; set; }
        public string DesignationName { get; set; }
        public int? BranchId { get; set; }
        public string BranchName { get; set; }
        public int? LocationId { get; set; }
        public string LocationName { get; set; }
        public int? VacancyId { get; set; }
        public bool? FlgDocSentForApproval { get; set; }
        public string DocStatus { get; set; }
        public string DocAprStatus { get; set; }
        public byte? DocType { get; set; }
        public int? DocNum { get; set; }
        public string ContractId { get; set; }
        public string ContractName { get; set; }
        public string Remarks { get; set; }
        public int? DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public bool? FlgSentToRegionalHead { get; set; }
        public bool? FlgSentToHr { get; set; }
        public string PrjCode { get; set; }
        public string PrjName { get; set; }
        public DateTime? EndingDate { get; set; }
        public bool? FlgRegionalHeadDecisionStatus { get; set; }
        public bool? FlgHrhiringDecisionStatus { get; set; }
        public DateTime? JoiningDate { get; set; }
        public decimal? ApprovedSalary { get; set; }
        public string AdditionalPoints { get; set; }
        public DateTime? AdminActionDate { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ApprovalDate { get; set; }

        public virtual MstEmployee Emp { get; set; }
        public virtual TrnsInterviewRecommendation InterviewRecommendation { get; set; }
        public virtual ICollection<TrnsRegionalHeadDetail> TrnsRegionalHeadDetails { get; set; }
    }
}
