using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsObloan
    {
        public int Id { get; set; }
        public int? EmpId { get; set; }
        public int? LoanId { get; set; }
        public decimal BalanceAmount { get; set; }
        public decimal? RecoverdAmount { get; set; }
        public decimal? TotalAmount { get; set; }
        public decimal? Installment { get; set; }
        public decimal? LoanAmount { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }
        public int CalId { get; set; }
        public string CalCode { get; set; }
        public DateTime? LoanDate { get; set; }

        public virtual MstEmployee Emp { get; set; }
        public virtual MstLoan Loan { get; set; }
    }
}
