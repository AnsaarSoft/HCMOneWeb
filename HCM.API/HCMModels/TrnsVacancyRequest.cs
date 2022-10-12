using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsVacancyRequest
    {
        public TrnsVacancyRequest()
        {
            MstCandidates = new HashSet<MstCandidate>();
            MstMpps = new HashSet<MstMpp>();
            TrnsRegionalHeadDetails = new HashSet<TrnsRegionalHeadDetail>();
            TrnsVacancyApplications = new HashSet<TrnsVacancyApplication>();
            TrnsVacancyAssessmentStatements = new HashSet<TrnsVacancyAssessmentStatement>();
        }

        public int Id { get; set; }
        public int? PositionId { get; set; }
        public int? Department { get; set; }
        public int? Location { get; set; }
        /// <summary>
        /// Replacement, Vacant , New Position
        /// </summary>
        public string Position { get; set; }
        public int? Branch { get; set; }
        public int? AgeMin { get; set; }
        public int? AgeMax { get; set; }
        public bool? AgePref { get; set; }
        public string SupervisorTitle { get; set; }
        public DateTime? EarliestStartDate { get; set; }
        public bool? ApprovedOrganogram { get; set; }
        public int? NoOfPostions { get; set; }
        public string Function { get; set; }
        public int? Grade { get; set; }
        /// <summary>
        /// Permanent, Contractual, Intern
        /// </summary>
        public string PositionType { get; set; }
        public string AnyTargetPerson { get; set; }
        public bool? JdAvailable { get; set; }
        public string BasicDuties { get; set; }
        /// <summary>
        /// Graduation, Masters,Diploma
        /// </summary>
        public string MinEducation { get; set; }
        public string SpecificDegree { get; set; }
        public string MinExperience { get; set; }
        public string SpecificIndustry { get; set; }
        public string Language { get; set; }
        public decimal? SalaryMin { get; set; }
        public decimal? SalaryMax { get; set; }
        public bool? Vehicle { get; set; }
        public bool? Fuel { get; set; }
        public bool? Computer { get; set; }
        public bool? CellPhone { get; set; }
        public decimal? CreditLimit { get; set; }
        public bool? Seating { get; set; }
        public string AlternateArrangement { get; set; }
        public string OtherFacility { get; set; }
        public string HofName { get; set; }
        public DateTime? HofDate { get; set; }
        public string HodName { get; set; }
        public DateTime? HodDate { get; set; }
        public string RrName { get; set; }
        public DateTime? RrDate { get; set; }
        public string Remarks { get; set; }
        public string HeadOfHr { get; set; }
        public string Coo { get; set; }
        /// <summary>
        /// 0 for Open ; 1 for closed
        /// </summary>
        public int? Status { get; set; }
        public int? EmployeeAssigned { get; set; }
        public bool? FlgonHold { get; set; }
        public bool? FlgActive { get; set; }
        public string OnHoldReason { get; set; }
        public string DocStatus { get; set; }
        public string DocAprStatus { get; set; }
        public int? DocType { get; set; }
        public int? DocNumber { get; set; }
        public int? MppRef { get; set; }
        public int OpenHeadCount { get; set; }
        public int? Designation { get; set; }
        public string Attachment { get; set; }
        public int? DesignationLevelId { get; set; }
        public string ReplaceEmpId { get; set; }
        public string Project { get; set; }
        public bool? FlgSendToHr { get; set; }
        public string Budgeted { get; set; }
        public string RecruitmentType { get; set; }
        public DateTime? VacancyExpirydate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? JobTitleId { get; set; }
        public string JobTitleName { get; set; }
        public int? TemporaryLocationId { get; set; }
        public string TemporaryLocationName { get; set; }

        public virtual MstBranch BranchNavigation { get; set; }
        public virtual MstDepartment DepartmentNavigation { get; set; }
        public virtual MstDesignation DesignationNavigation { get; set; }
        public virtual MstLocation LocationNavigation { get; set; }
        public virtual MstMpp MppRefNavigation { get; set; }
        public virtual ICollection<MstCandidate> MstCandidates { get; set; }
        public virtual ICollection<MstMpp> MstMpps { get; set; }
        public virtual ICollection<TrnsRegionalHeadDetail> TrnsRegionalHeadDetails { get; set; }
        public virtual ICollection<TrnsVacancyApplication> TrnsVacancyApplications { get; set; }
        public virtual ICollection<TrnsVacancyAssessmentStatement> TrnsVacancyAssessmentStatements { get; set; }
    }
}
