using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstDepartment
    {
        public MstDepartment()
        {
            CfgAlertManagementDepartments = new HashSet<CfgAlertManagementDepartment>();
            MstCandidates = new HashSet<MstCandidate>();
            MstEmployees = new HashSet<MstEmployee>();
            MstMpps = new HashSet<MstMpp>();
            MstParts = new HashSet<MstPart>();
            MstSubPartsStatements = new HashSet<MstSubPartsStatement>();
            MstSubPartsses = new HashSet<MstSubPartss>();
            NeskCfgDocHierarchies = new HashSet<NeskCfgDocHierarchy>();
            TrnsEmployeeExitInterviews = new HashSet<TrnsEmployeeExitInterview>();
            TrnsHeadBudgetDetails = new HashSet<TrnsHeadBudgetDetail>();
            TrnsInternalTransfers = new HashSet<TrnsInternalTransfer>();
            TrnsJobRequisitions = new HashSet<TrnsJobRequisition>();
            TrnsResignations = new HashSet<TrnsResignation>();
            TrnsVacancyRequests = new HashSet<TrnsVacancyRequest>();
        }

        public int Id { get; set; }
        public byte? DeptLevel { get; set; }
        public string Code { get; set; }
        public string DeptName { get; set; }
        public int? ParentDepartment { get; set; }
        public bool? FlgActive { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }
        public int? DeptHead { get; set; }
        public string DeptPrefix { get; set; }
        public int? SapdocEntry { get; set; }
        public decimal? BudgetValue { get; set; }

        public virtual ICollection<CfgAlertManagementDepartment> CfgAlertManagementDepartments { get; set; }
        public virtual ICollection<MstCandidate> MstCandidates { get; set; }
        public virtual ICollection<MstEmployee> MstEmployees { get; set; }
        public virtual ICollection<MstMpp> MstMpps { get; set; }
        public virtual ICollection<MstPart> MstParts { get; set; }
        public virtual ICollection<MstSubPartsStatement> MstSubPartsStatements { get; set; }
        public virtual ICollection<MstSubPartss> MstSubPartsses { get; set; }
        public virtual ICollection<NeskCfgDocHierarchy> NeskCfgDocHierarchies { get; set; }
        public virtual ICollection<TrnsEmployeeExitInterview> TrnsEmployeeExitInterviews { get; set; }
        public virtual ICollection<TrnsHeadBudgetDetail> TrnsHeadBudgetDetails { get; set; }
        public virtual ICollection<TrnsInternalTransfer> TrnsInternalTransfers { get; set; }
        public virtual ICollection<TrnsJobRequisition> TrnsJobRequisitions { get; set; }
        public virtual ICollection<TrnsResignation> TrnsResignations { get; set; }
        public virtual ICollection<TrnsVacancyRequest> TrnsVacancyRequests { get; set; }
    }
}
