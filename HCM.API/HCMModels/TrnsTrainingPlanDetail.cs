using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsTrainingPlanDetail
    {
        public int Id { get; set; }
        public int? TrainPlanId { get; set; }
        public bool? FlgStatus { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public virtual MstEmployee Employee { get; set; }
        public virtual TrnsTrainingPlan TrainPlan { get; set; }
    }
}
