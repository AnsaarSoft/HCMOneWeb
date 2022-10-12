using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsInterviewAssessmentDetail
    {
        public int Id { get; set; }
        public int AssessmentId { get; set; }
        public int StatementId { get; set; }
        public int? Score { get; set; }
        public string Comments { get; set; }

        public virtual TrnsInterviewAssessment Assessment { get; set; }
    }
}
