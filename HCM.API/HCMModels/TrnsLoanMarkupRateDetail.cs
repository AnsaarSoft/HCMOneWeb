using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsLoanMarkupRateDetail
    {
        public int Id { get; set; }
        public int? EmpId { get; set; }
        public decimal? LoanAmount { get; set; }
        public decimal? NoOfInstallments { get; set; }
        public decimal? MarkupRate { get; set; }
        public decimal? PrincipalAmount { get; set; }
        public decimal? InstallmentAmount { get; set; }
        public DateTime? ApprovedDate { get; set; }
    }
}
