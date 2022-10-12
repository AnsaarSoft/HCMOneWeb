using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsProbationCategorryCycleAttachment
    {
        public int Id { get; set; }
        public int? ProbationStatementId { get; set; }
        public int? ProbationCycleId { get; set; }

        public virtual MstProbationEvalCycle ProbationCycle { get; set; }
        public virtual MstProbationStatement ProbationStatement { get; set; }
    }
}
