using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsLoanRegister
    {
        public int Id { get; set; }
        public int? LoanId { get; set; }
        public int? LoanDocNum { get; set; }
        public int? Series { get; set; }
        public string EmpId { get; set; }
        public string BaseType { get; set; }
        public string BaseDocNum { get; set; }
        public decimal? LoanAmount { get; set; }
        public decimal? DueAmount { get; set; }
        public decimal? RecoveredAmount { get; set; }
        public DateTime? CreatedDt { get; set; }
        public DateTime? UpdatedDt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public virtual TrnsLoan Loan { get; set; }
    }
}
