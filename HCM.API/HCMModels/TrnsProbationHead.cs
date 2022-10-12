using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsProbationHead
    {
        public TrnsProbationHead()
        {
            TrnsProbationDetails = new HashSet<TrnsProbationDetail>();
        }

        public int Id { get; set; }
        public int? EmpId { get; set; }
        public int? ProbCycleId { get; set; }
        public bool? FlgActive { get; set; }
        public string StatusConfirmation { get; set; }
        public int? DocType { get; set; }
        public int? DocNumber { get; set; }
        public string DocAprStatus { get; set; }
        public string DocStatus { get; set; }
        public int? CycleLevel { get; set; }

        public virtual MstEmployee Emp { get; set; }
        public virtual MstProbationEvalCycle ProbCycle { get; set; }
        public virtual ICollection<TrnsProbationDetail> TrnsProbationDetails { get; set; }
    }
}
