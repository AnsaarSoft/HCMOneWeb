using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsPerofrmanceEvaluationDetail
    {
        public int Id { get; set; }
        public int? HeadId { get; set; }
        public int? StatementId { get; set; }
        public decimal? Score { get; set; }
        public int? EmpId { get; set; }
        public string Remarks { get; set; }
        public decimal? Actual { get; set; }
        public decimal? Percentage { get; set; }

        public virtual MstEmployee Emp { get; set; }
        public virtual TrnsPerformanceEvaluationHead Head { get; set; }
    }
}
