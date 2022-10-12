using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsSalaryArear
    {
        public TrnsSalaryArear()
        {
            TrnsSalaryArearDetails = new HashSet<TrnsSalaryArearDetail>();
        }

        public int Id { get; set; }
        public int? PayrollId { get; set; }
        public string PayrollName { get; set; }
        public int? PeriodId { get; set; }
        public string PeriodName { get; set; }
        public int? EmpId { get; set; }
        public bool? Status { get; set; }
        public string CalCode { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public decimal? BasicSalary { get; set; }
        public decimal? GrossSalary { get; set; }
        public decimal? PaidDays { get; set; }
        public int? MonthDays { get; set; }
        public decimal? EmpTaxblTotal { get; set; }
        public decimal? EmpTotalTax { get; set; }
        public string EmployeeId { get; set; }

        public virtual MstEmployee Emp { get; set; }
        public virtual ICollection<TrnsSalaryArearDetail> TrnsSalaryArearDetails { get; set; }
    }
}
