using System;
using System.Collections.Generic;

namespace HCM.API.Models
{
    public partial class TrnsObloan
    {
        public int Id { get; set; }
        public int? EmpId { get; set; }
        public int? FkloanId { get; set; }
        public decimal? BalanceAmount { get; set; }
        public decimal? RecoverdAmount { get; set; }
        public decimal? TotalAmount { get; set; }
        public decimal? Installment { get; set; }
        public int? CalId { get; set; }
        public string? CalCode { get; set; }
        public DateTime? LoanDate { get; set; }
    }
}
