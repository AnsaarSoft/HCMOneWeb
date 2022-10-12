using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsSalaryProcessRegister
    {
        public TrnsSalaryProcessRegister()
        {
            TrnsJeccregisters = new HashSet<TrnsJeccregister>();
            TrnsSalaryProcessRegisterDetails = new HashSet<TrnsSalaryProcessRegisterDetail>();
        }

        public int Id { get; set; }
        public int? PayrollId { get; set; }
        public int? PayrollPeriodId { get; set; }
        public string PayrollName { get; set; }
        public string PeriodName { get; set; }
        public int? EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpDepartment { get; set; }
        public string EmpDesignation { get; set; }
        public string EmpLocation { get; set; }
        public string EmpBranch { get; set; }
        public string EmpPosition { get; set; }
        public string EmpJobTitle { get; set; }
        public string EmpCostCenter { get; set; }
        public string EmpProject { get; set; }
        public string EmpD1 { get; set; }
        public string EmpD2 { get; set; }
        public string EmpD3 { get; set; }
        public string EmpD4 { get; set; }
        public string EmpD5 { get; set; }
        public decimal? EmpGross { get; set; }
        public decimal? EmpBasic { get; set; }
        public decimal? EmpOt { get; set; }
        public decimal? EmpElementTotal { get; set; }
        public decimal? EmpAdvace { get; set; }
        public decimal? EmpBonus { get; set; }
        public decimal? EmpLoan { get; set; }
        public decimal? EmpExpense { get; set; }
        public decimal? EmpArrears { get; set; }
        public decimal? EmpRetroElement { get; set; }
        public int? Jenum { get; set; }
        public int? JenumA1 { get; set; }
        public int? SalaryStatus { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }
        public decimal? EmpTaxblTotal { get; set; }
        public decimal? EmpTotalTax { get; set; }
        public decimal? DaysPaid { get; set; }
        public bool? FlgHoldPayment { get; set; }
        public int? MonthDays { get; set; }
        public bool? FlgEmailed { get; set; }
        public bool? FlgDisburse { get; set; }
        public int? OpdocEntry { get; set; }
        public string CalCode { get; set; }

        public virtual MstEmployee Emp { get; set; }
        public virtual CfgPayrollDefination Payroll { get; set; }
        public virtual CfgPeriodDate PayrollPeriod { get; set; }
        public virtual ICollection<TrnsJeccregister> TrnsJeccregisters { get; set; }
        public virtual ICollection<TrnsSalaryProcessRegisterDetail> TrnsSalaryProcessRegisterDetails { get; set; }
    }
}
