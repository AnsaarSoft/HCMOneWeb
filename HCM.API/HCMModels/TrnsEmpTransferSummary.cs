using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsEmpTransferSummary
    {
        public int InternalId { get; set; }
        public int? EmpId { get; set; }
        public int? Location { get; set; }
        public int? DocDate { get; set; }
        public int? PeriodId { get; set; }
        public int? PeriodDays { get; set; }
        public int? DayCount { get; set; }
        public decimal? FactorDistribution { get; set; }
    }
}
