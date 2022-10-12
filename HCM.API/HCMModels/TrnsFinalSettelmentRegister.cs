using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsFinalSettelmentRegister
    {
        public TrnsFinalSettelmentRegister()
        {
            TrnsFinalSettelmentRegisterDetails = new HashSet<TrnsFinalSettelmentRegisterDetail>();
        }

        public int Id { get; set; }
        public int? FsheadId { get; set; }
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
        public decimal? EmpGross { get; set; }
        public decimal? EmpBasic { get; set; }
        public decimal? EmpOt { get; set; }
        public decimal? EmpElementTotal { get; set; }
        public decimal? EmpAdvance { get; set; }
        public decimal? EmpBonus { get; set; }
        public decimal? EmpLoan { get; set; }
        public decimal? EmpExpense { get; set; }
        public decimal? EmpArrears { get; set; }
        public decimal? EmpRetroElement { get; set; }
        public int? Jenum { get; set; }
        public int? A1jenum { get; set; }
        public int FinalSettlementStatus { get; set; }
        public decimal? EmpTaxblTotal { get; set; }
        public decimal? EmpTotalTax { get; set; }
        public decimal? DaysPaid { get; set; }
        public int? MonthDays { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdateBy { get; set; }
        public int? EosType { get; set; }

        public virtual MstEmployee Emp { get; set; }
        public virtual TrnsFshead Fshead { get; set; }
        public virtual CfgPayrollDefination Payroll { get; set; }
        public virtual CfgPeriodDate PayrollPeriod { get; set; }
        public virtual ICollection<TrnsFinalSettelmentRegisterDetail> TrnsFinalSettelmentRegisterDetails { get; set; }
    }
}
