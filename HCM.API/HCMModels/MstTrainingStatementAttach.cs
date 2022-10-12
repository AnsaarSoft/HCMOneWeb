using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstTrainingStatementAttach
    {
        public int Id { get; set; }
        public int? TrainEvalCategoryId { get; set; }
        public int? StatementId { get; set; }
        public int? TrainingCategoryId { get; set; }
        public int? CourseId { get; set; }
        public int? StatementScore { get; set; }
        public string Statement { get; set; }
        public bool? FlgActive { get; set; }
    }
}
