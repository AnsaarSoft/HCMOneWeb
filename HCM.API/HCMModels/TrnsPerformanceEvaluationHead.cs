using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsPerformanceEvaluationHead
    {
        public TrnsPerformanceEvaluationHead()
        {
            MstTrainingNeedAssesments = new HashSet<MstTrainingNeedAssesment>();
            TrnsPerofrmanceEvaluationDetails = new HashSet<TrnsPerofrmanceEvaluationDetail>();
        }

        public int Id { get; set; }
        public int? FiscalYear { get; set; }
        public int? EmpId { get; set; }
        public decimal? TotalScore { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool? FlgActive { get; set; }
        public int? EvaluationLevel { get; set; }
        public int? AppraiserId { get; set; }
        public string DocStatus { get; set; }
        public string DocAprStatus { get; set; }
        public string AppraiserRemarks { get; set; }
        public string EmployeeSigningComments { get; set; }
        public bool? FlgEmployeeSigned { get; set; }
        public bool? FlgManagerRated { get; set; }
        public bool? FlgPromotionRecomend { get; set; }
        public string Comments { get; set; }
        public string Improvement { get; set; }
        public string Trainings { get; set; }
        public bool? FlgPromoted { get; set; }
        public string Hodcomments { get; set; }
        public string Hrcomments { get; set; }
        public string FinalRating { get; set; }
        public decimal? IncrementPercentage { get; set; }
        public int? YearId { get; set; }
        public int? DocType { get; set; }
        public decimal? AnomalyPercentage { get; set; }
        public decimal? AnamolyAmount { get; set; }
        public decimal? CurrentSalary { get; set; }
        public decimal? IncrementedSalary { get; set; }
        public bool? FlgHodapproved { get; set; }
        public int? TermId { get; set; }
        public DateTime? AppraiserRatingDate { get; set; }
        public DateTime? EmployeeSigningDate { get; set; }
        public bool? FlgIncluded { get; set; }
        public bool? SalaryChanged { get; set; }
        public decimal? PerformanceBonus { get; set; }
        public decimal? CommitmentAllowance { get; set; }
        public decimal? HranamolyPercentage { get; set; }
        public decimal? HranamolyAmount { get; set; }
        public bool? FlgRevert { get; set; }
        public string EmployeeAssessmentRemarks { get; set; }
        public string Ceoremarks { get; set; }
        public bool? FlgCeoSigned { get; set; }

        public virtual MstEmployee Appraiser { get; set; }
        public virtual MstEmployee Emp { get; set; }
        public virtual MstPerformanceTerm Term { get; set; }
        public virtual ICollection<MstTrainingNeedAssesment> MstTrainingNeedAssesments { get; set; }
        public virtual ICollection<TrnsPerofrmanceEvaluationDetail> TrnsPerofrmanceEvaluationDetails { get; set; }
    }
}
