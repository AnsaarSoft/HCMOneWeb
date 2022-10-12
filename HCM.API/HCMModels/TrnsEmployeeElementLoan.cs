using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsEmployeeElementLoan
    {
        public int Id { get; set; }
        public int? EmpElmtId { get; set; }
        public int? LoanId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? LoanAmount { get; set; }
        public decimal? MarkUpRate { get; set; }
        public decimal? TotalLoanAmount { get; set; }
        public decimal? InstallmentAmount { get; set; }
        public bool? FlgActive { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }

        public virtual TrnsEmployeeElement EmpElmt { get; set; }
        public virtual MstLoan Loan { get; set; }
    }
}
