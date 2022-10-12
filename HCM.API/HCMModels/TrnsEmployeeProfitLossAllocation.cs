using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsEmployeeProfitLossAllocation
    {
        public int Id { get; set; }
        public int? PayrollId { get; set; }
        public int? PeriodId { get; set; }
        public DateTime? PostingDate { get; set; }
        public decimal? ProfitLossPerYear { get; set; }
        public int? EmpId { get; set; }
        public string EmployeeName { get; set; }
        public DateTime? JoiningDate { get; set; }
        public int? ElementId { get; set; }
        public decimal? OpeningBalance { get; set; }
        public decimal? OpeningEmpPf { get; set; }
        public decimal? OpeningEmprPf { get; set; }
        public decimal? YearToDatePf { get; set; }
        public decimal? EmpContribution { get; set; }
        public decimal? EmprContribution { get; set; }
        public decimal? TotalContribution { get; set; }
        public decimal? WithdrawnValue { get; set; }
        public decimal? ClosingBalance { get; set; }
        public decimal? AllocatedProfitLoss { get; set; }
        public decimal? ClosingBalanceAfterAllocation { get; set; }
        public string Status { get; set; }
        public string CalCode { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual MstEmployee Emp { get; set; }
    }
}
