using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstTrainingBudget
    {
        public MstTrainingBudget()
        {
            TrnsTrainingPlans = new HashSet<TrnsTrainingPlan>();
        }

        public int Id { get; set; }
        public int? DocNum { get; set; }
        public int? FiscalYearId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public decimal? TrainingBudget { get; set; }
        public decimal? AdminBudget { get; set; }
        public decimal? VenueBudget { get; set; }
        public decimal? TotalBudget { get; set; }
        public decimal? RemainingBudget { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public int? TrainingCategoryId { get; set; }
        public decimal? LogisticBudget { get; set; }

        public virtual ICollection<TrnsTrainingPlan> TrnsTrainingPlans { get; set; }
    }
}
