using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsTrainingFeedback
    {
        public TrnsTrainingFeedback()
        {
            TrnsTrainingFeedbackDetails = new HashSet<TrnsTrainingFeedbackDetail>();
        }

        public int Id { get; set; }
        public int? Tid { get; set; }
        public int? EmpId { get; set; }
        public string EmpDep { get; set; }
        public string EmpDesig { get; set; }
        public string TrainerName { get; set; }
        public decimal? TrainingHours { get; set; }
        public DateTime? FromAttend { get; set; }
        public DateTime? ToAttend { get; set; }
        public string Remarks { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public bool? FlgActive { get; set; }

        public virtual MstEmployee Emp { get; set; }
        public virtual TrnsTrainingPlan TidNavigation { get; set; }
        public virtual ICollection<TrnsTrainingFeedbackDetail> TrnsTrainingFeedbackDetails { get; set; }
    }
}
