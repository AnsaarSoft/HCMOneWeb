using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsInterviewRecommendation
    {
        public TrnsInterviewRecommendation()
        {
            TrnsOfferLetters = new HashSet<TrnsOfferLetter>();
            TrnsRegionalHeadDetails = new HashSet<TrnsRegionalHeadDetail>();
        }

        public int Id { get; set; }
        public int? CandidateId { get; set; }
        public decimal? Score { get; set; }
        public string FinalVerdict { get; set; }
        public int? InterviewCallId { get; set; }
        public bool? FlgDocSentForApproval { get; set; }
        public decimal? RecommendedSalary { get; set; }
        public decimal? OfferedSalary { get; set; }
        public int? DesignationId { get; set; }
        public string DesignationName { get; set; }
        public int? BranchId { get; set; }
        public string BranchName { get; set; }
        public int? LocationId { get; set; }
        public string LocationName { get; set; }
        public int? VacancyId { get; set; }
        public string DocStatus { get; set; }
        public string DocAprStatus { get; set; }
        public byte? DocType { get; set; }
        public int? DocNum { get; set; }
        public string ContractId { get; set; }
        public string ContractName { get; set; }
        public int? EmpId { get; set; }

        public virtual MstCandidate Candidate { get; set; }
        public virtual MstEmployee Emp { get; set; }
        public virtual TrnsInterviewCall InterviewCall { get; set; }
        public virtual ICollection<TrnsOfferLetter> TrnsOfferLetters { get; set; }
        public virtual ICollection<TrnsRegionalHeadDetail> TrnsRegionalHeadDetails { get; set; }
    }
}
