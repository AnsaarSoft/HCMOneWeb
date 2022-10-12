using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstTrainingEvaluationCategory
    {
        public MstTrainingEvaluationCategory()
        {
            MstTrainingStatements = new HashSet<MstTrainingStatement>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool? FlgActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public int? CategoryWeightage { get; set; }
        public int? CategoryId { get; set; }
        public int? CourseId { get; set; }

        public virtual ICollection<MstTrainingStatement> MstTrainingStatements { get; set; }
    }
}
