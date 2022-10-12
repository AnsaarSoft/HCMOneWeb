using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsProbationAssesHead
    {
        public TrnsProbationAssesHead()
        {
            TrnsProbationAssesDetails = new HashSet<TrnsProbationAssesDetail>();
        }

        public int Id { get; set; }
        public int? EmpId { get; set; }
        public int? ProbCycleId { get; set; }
        public bool? FlgActive { get; set; }
        public string StatusConfirmation { get; set; }
        public int? DocType { get; set; }
        public int? DocNum { get; set; }
        public string DocAprStatus { get; set; }
        public string DocStatus { get; set; }
        public int? CycleLevel { get; set; }
        public string Comments { get; set; }
        public decimal? TotalScore { get; set; }
        public bool? IsIncreementRecommended { get; set; }
        public string RecommendedAmount { get; set; }
        public string IncrementedAmount { get; set; }

        public virtual MstEmployee Emp { get; set; }
        public virtual MstProbationEvalCycle ProbCycle { get; set; }
        public virtual ICollection<TrnsProbationAssesDetail> TrnsProbationAssesDetails { get; set; }
    }
}
