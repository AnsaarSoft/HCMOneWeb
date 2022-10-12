using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class LogEmployeeElementDetail
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public decimal? BasicSalary { get; set; }
        public decimal? GrossSalary { get; set; }
        public long? PayrollId { get; set; }
        public long? PeriodId { get; set; }
        public int? ElementId { get; set; }
        public decimal? Amount { get; set; }
        public decimal? RetroAmount { get; set; }
        public bool? FlgRetro { get; set; }
        public bool? FlgPayroll { get; set; }
        public bool? FlgModified { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }
        public string ElementType { get; set; }
        public string ValueType { get; set; }
        public decimal? Value { get; set; }
        public decimal? EmpContr { get; set; }
        public decimal? EmplrContr { get; set; }
        public bool? FlgTaxable { get; set; }
        public bool? FlgStandard { get; set; }
        public bool? FlgActive { get; set; }
        public bool? FlgOneTimeConsumed { get; set; }
        public long? ConsumedOn { get; set; }
        public string SourceType { get; set; }
        public long? SourceId { get; set; }
        public string Remarks { get; set; }
    }
}
