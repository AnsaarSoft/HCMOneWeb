using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsSalaryClassification
    {
        public int InternalId { get; set; }
        public int? EmpId { get; set; }
        public int? PeriodId { get; set; }
        public int? Location { get; set; }
        public string DAccountCode { get; set; }
        public string DAccountDesc { get; set; }
        public decimal? LineValue { get; set; }
        public string CAccountCode { get; set; }
        public string CAccountDesc { get; set; }
        public int? LocationId { get; set; }
        public string DisburseType { get; set; }
    }
}
