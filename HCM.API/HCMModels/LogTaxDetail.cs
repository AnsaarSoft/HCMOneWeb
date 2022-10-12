using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class LogTaxDetail
    {
        public int InternalId { get; set; }
        public string EmpId { get; set; }
        public string EmpName { get; set; }
        public string BasicSalary { get; set; }
        public string GrossSalary { get; set; }
        public string TaxableSalary { get; set; }
        public string TaxableWop { get; set; }
        public string TaxableOt { get; set; }
        public string ExpectedYearlySalary { get; set; }
        public string ExpectedTaxAmount { get; set; }
        public string ExpectedYearlySalaryI { get; set; }
        public string ExpectedTaxAmountI { get; set; }
        public string Obsalary { get; set; }
        public string Obtax { get; set; }
        public string ProjectedIncome { get; set; }
        public string AlreadyProcessedIncome { get; set; }
        public string PeriodName { get; set; }
        public string IncentiveAmount { get; set; }
        public string IncentiveTax { get; set; }
        public string TaxAdjustmentYearly { get; set; }
        public string TaxAdjustmentMonthly { get; set; }
        public string SlabCode { get; set; }
        public string SlabMin { get; set; }
        public string SlabMax { get; set; }
        public string SlabFix { get; set; }
        public string SlabPer { get; set; }
        public string SlabCodeI { get; set; }
        public string SlabMinI { get; set; }
        public string SlabMaxI { get; set; }
        public string SlabFixI { get; set; }
        public string SlabPerI { get; set; }
        public string SalaryOnlyTax { get; set; }
        public string TotalTaxValue { get; set; }
        public string LogType { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreateDt { get; set; }
    }
}
