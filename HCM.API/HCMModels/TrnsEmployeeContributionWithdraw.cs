using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsEmployeeContributionWithdraw
    {
        public int Id { get; set; }
        public int? PayrollId { get; set; }
        public int? PeriodId { get; set; }
        public int? EmpId { get; set; }
        public string EmployeeName { get; set; }
        public DateTime? JoiningDate { get; set; }
        public int? ElementId { get; set; }
        public decimal? OpeningPf { get; set; }
        public decimal? YearToDatePf { get; set; }
        public decimal? EmpContribution { get; set; }
        public decimal? EmprContribution { get; set; }
        public decimal? TotalContribution { get; set; }
        public decimal? EmpWithdraw { get; set; }
        public decimal? EmprWithdraw { get; set; }
        public string Status { get; set; }
        public int? JeNum { get; set; }
        public int? Sbono { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public decimal? OpeningBalance { get; set; }
        public decimal? OpeningPfemp { get; set; }
        public decimal? OpeningPfempr { get; set; }
        public decimal? ClosingBalance { get; set; }
        public string CalCode { get; set; }

        public virtual MstEmployee Emp { get; set; }
    }
}
