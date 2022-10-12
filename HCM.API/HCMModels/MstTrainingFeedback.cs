using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstTrainingFeedback
    {
        public MstTrainingFeedback()
        {
            TrnsTrainingFeedbackDetails = new HashSet<TrnsTrainingFeedbackDetail>();
        }

        public int Id { get; set; }
        public int? TrainPlanId { get; set; }
        public string Statement { get; set; }
        public bool? FlgActive { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual TrnsTrainingPlan TrainPlan { get; set; }
        public virtual ICollection<TrnsTrainingFeedbackDetail> TrnsTrainingFeedbackDetails { get; set; }
    }
}
