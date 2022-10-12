using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsLoanInstallmentPlan
    {
        public int Id { get; set; }
        public int? LoanId { get; set; }
        public decimal? InstallmentAmount { get; set; }
        public int? InstallemntNumber { get; set; }
        public bool? FlgUsed { get; set; }
        public bool? FlgRevised { get; set; }
        public string Reference { get; set; }
        public int? Sboid { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DueDate { get; set; }

        public virtual TrnsLoan Loan { get; set; }
    }
}
