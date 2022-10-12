using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsProbationDetail
    {
        public int Id { get; set; }
        public int? HeadId { get; set; }
        public int? CriteriaId { get; set; }
        public string Progress { get; set; }
        public string CommentsHr { get; set; }

        public virtual MstProbationEvalCriterion Criteria { get; set; }
        public virtual TrnsProbationHead Head { get; set; }
    }
}
