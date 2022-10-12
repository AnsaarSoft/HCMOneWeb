using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsJobRequisition
    {
        public TrnsJobRequisition()
        {
            TrnsJobAdvertisings = new HashSet<TrnsJobAdvertising>();
            TrnsJrdetailCertifications = new HashSet<TrnsJrdetailCertification>();
            TrnsJrdetailCompetancies = new HashSet<TrnsJrdetailCompetancy>();
            TrnsJrdetailEducations = new HashSet<TrnsJrdetailEducation>();
            TrnsJrdetailSkills = new HashSet<TrnsJrdetailSkill>();
        }

        public int Id { get; set; }
        public int? DocNum { get; set; }
        /// <summary>
        /// 15
        /// </summary>
        public byte? DocType { get; set; }
        public int? Series { get; set; }
        public int? BaseDoc { get; set; }
        public string DocStatus { get; set; }
        public string DocStatusLov { get; set; }
        public string DocAprStatus { get; set; }
        public string DocAprStatusLov { get; set; }
        public DateTime? PostingDate { get; set; }
        public DateTime? ValidUpto { get; set; }
        public int? DesignationId { get; set; }
        public string Designation { get; set; }
        public int? LocationId { get; set; }
        public string Location { get; set; }
        public int? BranchId { get; set; }
        public string Branch { get; set; }
        public int? DeptId { get; set; }
        public string Department { get; set; }
        public string RequestedBy { get; set; }
        public byte? ExperianceFrom { get; set; }
        public byte? ExperianceTo { get; set; }
        public string ExperianceUnit { get; set; }
        public decimal? BudgetSalaryFrom { get; set; }
        public decimal? BudgetSalaryTo { get; set; }
        public decimal? RecommendedSalary { get; set; }
        public string ApprovedBy { get; set; }
        public decimal? AllocatedBudget { get; set; }
        public string VacantPosition { get; set; }
        public string AppOccupancy { get; set; }
        public string RejOccupancy { get; set; }
        public byte? NoOfVacancy { get; set; }
        public string ContractType { get; set; }
        public string ContractTypeLov { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string CostCenter { get; set; }
        public string Remarks { get; set; }
        public string CompensationRemarks { get; set; }
        public bool FlgTempBasis { get; set; }
        public bool FlgAdvertised { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }

        public virtual MstBranch BranchNavigation { get; set; }
        public virtual MstDepartment Dept { get; set; }
        public virtual MstDesignation DesignationNavigation { get; set; }
        public virtual MstLocation LocationNavigation { get; set; }
        public virtual ICollection<TrnsJobAdvertising> TrnsJobAdvertisings { get; set; }
        public virtual ICollection<TrnsJrdetailCertification> TrnsJrdetailCertifications { get; set; }
        public virtual ICollection<TrnsJrdetailCompetancy> TrnsJrdetailCompetancies { get; set; }
        public virtual ICollection<TrnsJrdetailEducation> TrnsJrdetailEducations { get; set; }
        public virtual ICollection<TrnsJrdetailSkill> TrnsJrdetailSkills { get; set; }
    }
}
