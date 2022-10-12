using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsTrainingEvaluationDetail
    {
        public int Id { get; set; }
        public int? HeadId { get; set; }
        public int? StatementId { get; set; }
        public int? StatementScore { get; set; }
        public int? ObtainStatementScore { get; set; }
        public string Remarks { get; set; }

        public virtual TrnsTrainingEvaluation Head { get; set; }
    }
}
