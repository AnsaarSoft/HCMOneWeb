using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstTrainingStatement
    {
        public int Id { get; set; }
        public int? TrainingEvalCategoryId { get; set; }
        public string Statement { get; set; }
        public bool? FlgActive { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? StatementWeightage { get; set; }

        public virtual MstTrainingEvaluationCategory TrainingEvalCategory { get; set; }
    }
}
