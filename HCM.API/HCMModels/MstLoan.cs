using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstLoan
    {
        public MstLoan()
        {
            TrnsEmployeeElementLoans = new HashSet<TrnsEmployeeElementLoan>();
            TrnsLoanDetails = new HashSet<TrnsLoanDetail>();
            TrnsObloans = new HashSet<TrnsObloan>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal? LoanValue { get; set; }
        public bool? FlgPfloan { get; set; }
        public bool? FlgActive { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }
        public int? ElementId { get; set; }
        public decimal? MarkUpRate { get; set; }
        public bool? FlgGratuity { get; set; }
        public decimal? TotalLoanCap { get; set; }
        public bool? FlgPf { get; set; }
        public string ElementCode { get; set; }
        public decimal? Pfcap { get; set; }
        public string GratuityCode { get; set; }
        public bool? FlgMultiple { get; set; }

        public virtual ICollection<TrnsEmployeeElementLoan> TrnsEmployeeElementLoans { get; set; }
        public virtual ICollection<TrnsLoanDetail> TrnsLoanDetails { get; set; }
        public virtual ICollection<TrnsObloan> TrnsObloans { get; set; }
    }
}
