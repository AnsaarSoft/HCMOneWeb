using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstTrainingNeedAssesment
    {
        public int Id { get; set; }
        public int? EvaluationId { get; set; }
        public int? EmployeeId { get; set; }
        public int? CourseId { get; set; }
        public int? CategoryId { get; set; }
        public bool? FlgActive { get; set; }

        public virtual MstTrainingCategory Category { get; set; }
        public virtual MstTrainingCourse Course { get; set; }
        public virtual MstEmployee Employee { get; set; }
        public virtual TrnsPerformanceEvaluationHead Evaluation { get; set; }
    }
}
