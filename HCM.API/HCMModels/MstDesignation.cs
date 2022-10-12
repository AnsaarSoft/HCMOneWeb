using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstDesignation
    {
        public MstDesignation()
        {
            MstCandidates = new HashSet<MstCandidate>();
            MstDesigLinkCompetencies = new HashSet<MstDesigLinkCompetency>();
            MstDesigLinkGrades = new HashSet<MstDesigLinkGrade>();
            MstEmployees = new HashSet<MstEmployee>();
            MstMpps = new HashSet<MstMpp>();
            MstParts = new HashSet<MstPart>();
            MstProbationCategories = new HashSet<MstProbationCategory>();
            MstProbationCategoryChildDesignations = new HashSet<MstProbationCategoryChildDesignation>();
            MstProbationStatements = new HashSet<MstProbationStatement>();
            MstProbationStatementsChildDesignations = new HashSet<MstProbationStatementsChildDesignation>();
            MstSubPartsStatements = new HashSet<MstSubPartsStatement>();
            MstSubPartsses = new HashSet<MstSubPartss>();
            MstTravelExpenses = new HashSet<MstTravelExpense>();
            TrnsHeadBudgetDetails = new HashSet<TrnsHeadBudgetDetail>();
            TrnsInterviewAssessments = new HashSet<TrnsInterviewAssessment>();
            TrnsJobRequisitions = new HashSet<TrnsJobRequisition>();
            TrnsSalaryChanges = new HashSet<TrnsSalaryChange>();
            TrnsVacancyRequests = new HashSet<TrnsVacancyRequest>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }
        public int? GradeId { get; set; }
        public bool? FlgActive { get; set; }
        public int? SbodocEntry { get; set; }

        public virtual MstGrading Grade { get; set; }
        public virtual ICollection<MstCandidate> MstCandidates { get; set; }
        public virtual ICollection<MstDesigLinkCompetency> MstDesigLinkCompetencies { get; set; }
        public virtual ICollection<MstDesigLinkGrade> MstDesigLinkGrades { get; set; }
        public virtual ICollection<MstEmployee> MstEmployees { get; set; }
        public virtual ICollection<MstMpp> MstMpps { get; set; }
        public virtual ICollection<MstPart> MstParts { get; set; }
        public virtual ICollection<MstProbationCategory> MstProbationCategories { get; set; }
        public virtual ICollection<MstProbationCategoryChildDesignation> MstProbationCategoryChildDesignations { get; set; }
        public virtual ICollection<MstProbationStatement> MstProbationStatements { get; set; }
        public virtual ICollection<MstProbationStatementsChildDesignation> MstProbationStatementsChildDesignations { get; set; }
        public virtual ICollection<MstSubPartsStatement> MstSubPartsStatements { get; set; }
        public virtual ICollection<MstSubPartss> MstSubPartsses { get; set; }
        public virtual ICollection<MstTravelExpense> MstTravelExpenses { get; set; }
        public virtual ICollection<TrnsHeadBudgetDetail> TrnsHeadBudgetDetails { get; set; }
        public virtual ICollection<TrnsInterviewAssessment> TrnsInterviewAssessments { get; set; }
        public virtual ICollection<TrnsJobRequisition> TrnsJobRequisitions { get; set; }
        public virtual ICollection<TrnsSalaryChange> TrnsSalaryChanges { get; set; }
        public virtual ICollection<TrnsVacancyRequest> TrnsVacancyRequests { get; set; }
    }
}
