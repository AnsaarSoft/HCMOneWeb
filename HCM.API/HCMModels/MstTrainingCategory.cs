using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstTrainingCategory
    {
        public MstTrainingCategory()
        {
            MstTrainingNeedAssesments = new HashSet<MstTrainingNeedAssesment>();
            TrnsTrainingPlans = new HashSet<TrnsTrainingPlan>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool? FlgActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string TypeOfTraining { get; set; }
        public string TrainingPlace { get; set; }
        public int? ModeId { get; set; }
        public string ModeDescription { get; set; }

        public virtual ICollection<MstTrainingNeedAssesment> MstTrainingNeedAssesments { get; set; }
        public virtual ICollection<TrnsTrainingPlan> TrnsTrainingPlans { get; set; }
    }
}
