using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstCandidate
    {
        public MstCandidate()
        {
            MstCandidateEducations = new HashSet<MstCandidateEducation>();
            MstCandidatePastExperiences = new HashSet<MstCandidatePastExperience>();
            MstCandidateQualifications = new HashSet<MstCandidateQualification>();
            MstCandidateReferences = new HashSet<MstCandidateReference>();
            TrnsInterviewAssessments = new HashSet<TrnsInterviewAssessment>();
            TrnsInterviewCalls = new HashSet<TrnsInterviewCall>();
            TrnsInterviewRecommendations = new HashSet<TrnsInterviewRecommendation>();
        }

        public int Id { get; set; }
        public int CandidateNo { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int? Designation { get; set; }
        public int? Department { get; set; }
        public int? Branch { get; set; }
        public int? Location { get; set; }
        public int? VacancyNo { get; set; }
        public string UserCode { get; set; }
        public string MobilePhone { get; set; }
        public string Pager { get; set; }
        public string HomePhone { get; set; }
        public string Fax { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string OfficePhone { get; set; }
        public string Extension { get; set; }
        public string WStreet { get; set; }
        public string WStreetNo { get; set; }
        public string WBlock { get; set; }
        public string WBuildingFloor { get; set; }
        public string WZipCode { get; set; }
        public string WCity { get; set; }
        public string WCounty { get; set; }
        public string WState { get; set; }
        public string WCountry { get; set; }
        public string HStreetNo { get; set; }
        public string HStreet { get; set; }
        public string HBlock { get; set; }
        public string HBuildingFloor { get; set; }
        public string HZipCode { get; set; }
        public string HCity { get; set; }
        public string HCounty { get; set; }
        public string HState { get; set; }
        public string HCountry { get; set; }
        public int? AssignedTo { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdatedBy { get; set; }
        public bool? IsShortListed { get; set; }
        public DateTime? ApplicationDate { get; set; }
        public string StaffingStatus { get; set; }
        public int? LineManager { get; set; }
        public string Gender { get; set; }
        public DateTime? Dob { get; set; }
        public string CountryofBirth { get; set; }
        public string MartialStatus { get; set; }
        public int? NoOfChildren { get; set; }
        public string NicNo { get; set; }
        public string PassportNo { get; set; }
        public DateTime? PassportExpiry { get; set; }
        public string Citizenship { get; set; }
        public decimal? CurrentSalary { get; set; }
        public decimal? ExpectedSalary { get; set; }
        public decimal? RecommendedSalary { get; set; }
        public string BankName { get; set; }
        public string BankAccount { get; set; }
        public string Bankbranch { get; set; }
        public string Remarks { get; set; }
        public bool? DocStatus { get; set; }
        public bool? InterviewDecided { get; set; }
        public string CvPath { get; set; }
        public string ImgPath { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public DateTime? Passwordexpiry { get; set; }
        public string Last5passwords { get; set; }
        public int? Experience { get; set; }
        public string Attachment { get; set; }
        public int? ReferedById { get; set; }
        public string ReferedByName { get; set; }
        public bool? InternalReferred { get; set; }
        public string PersonalTitle { get; set; }
        public string FatherName { get; set; }
        public string FatherOrg { get; set; }
        public string FatherDesg { get; set; }
        public string FatherTele { get; set; }
        /// <summary>
        /// E=Experienced, T=Trainee, Default value N=Not selected
        /// </summary>
        public string ExpOrTrainee { get; set; }
        public bool? PriorityAea { get; set; }
        public bool? PriorityAia { get; set; }
        public bool? PriorityBea { get; set; }
        public bool? PriorityBia { get; set; }
        public int? PreferredLoc { get; set; }
        public string PreferredLocName { get; set; }
        public int? ResetCount { get; set; }

        public virtual MstEmployee AssignedToNavigation { get; set; }
        public virtual MstBranch BranchNavigation { get; set; }
        public virtual MstDepartment DepartmentNavigation { get; set; }
        public virtual MstDesignation DesignationNavigation { get; set; }
        public virtual MstLocation LocationNavigation { get; set; }
        public virtual TrnsVacancyRequest VacancyNoNavigation { get; set; }
        public virtual ICollection<MstCandidateEducation> MstCandidateEducations { get; set; }
        public virtual ICollection<MstCandidatePastExperience> MstCandidatePastExperiences { get; set; }
        public virtual ICollection<MstCandidateQualification> MstCandidateQualifications { get; set; }
        public virtual ICollection<MstCandidateReference> MstCandidateReferences { get; set; }
        public virtual ICollection<TrnsInterviewAssessment> TrnsInterviewAssessments { get; set; }
        public virtual ICollection<TrnsInterviewCall> TrnsInterviewCalls { get; set; }
        public virtual ICollection<TrnsInterviewRecommendation> TrnsInterviewRecommendations { get; set; }
    }
}
