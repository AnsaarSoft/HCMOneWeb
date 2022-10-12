using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class PfLoanAmtView
    {
        public int Id { get; set; }
        public string CalCode { get; set; }
        public int? EmpId { get; set; }
        public string PeriodName { get; set; }
        public decimal? PfLoanAmt { get; set; }
    }
}
