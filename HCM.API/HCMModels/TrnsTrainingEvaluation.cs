using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsTrainingEvaluation
    {
        public TrnsTrainingEvaluation()
        {
            TrnsTrainingEvaluationDetails = new HashSet<TrnsTrainingEvaluationDetail>();
        }

        public int Id { get; set; }
        public int? TrainPlanId { get; set; }
        public bool? FlgFullAttendance { get; set; }
        public string FullAttendanceRemarks { get; set; }
        public bool? FlgFormalDress { get; set; }
        public string FormalDressRemarks { get; set; }
        public bool? FlgEthics { get; set; }
        public string EthicsRemarks { get; set; }
        public bool? FlgQuestions { get; set; }
        public string QuestionsRemarks { get; set; }
        public bool? FlgSpirit { get; set; }
        public string SpiritRemarks { get; set; }
        public bool? FlgReadToLearn { get; set; }
        public string ReadToLearnRemarks { get; set; }
        public string Remarks { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public int? EmpId { get; set; }
        public int? VenueId { get; set; }
        public int? TotalScore { get; set; }
        public string Status { get; set; }
        public int? CategoryId { get; set; }
        public int? CourseId { get; set; }

        public virtual MstEmployee Emp { get; set; }
        public virtual TrnsTrainingPlan TrainPlan { get; set; }
        public virtual MstTrainingVenue Venue { get; set; }
        public virtual ICollection<TrnsTrainingEvaluationDetail> TrnsTrainingEvaluationDetails { get; set; }
    }
}
