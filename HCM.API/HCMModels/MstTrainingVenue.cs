using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstTrainingVenue
    {
        public MstTrainingVenue()
        {
            TrnsTrainingEvaluations = new HashSet<TrnsTrainingEvaluation>();
            TrnsTrainingPlans = new HashSet<TrnsTrainingPlan>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool? FlgActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public virtual ICollection<TrnsTrainingEvaluation> TrnsTrainingEvaluations { get; set; }
        public virtual ICollection<TrnsTrainingPlan> TrnsTrainingPlans { get; set; }
    }
}
