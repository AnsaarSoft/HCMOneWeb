using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsEmployeeElementDetail
    {
        public int Id { get; set; }
        public int? Fkid { get; set; }
        public int? ElementId { get; set; }
        public int? EmpElmtId { get; set; }
        public string ElementCode { get; set; }
        public string ElementDescription { get; set; }
        public string ElementType { get; set; }
        public string Type { get; set; }
        public string ElementValueType { get; set; }
        public decimal? Value { get; set; }
        public decimal? EmpContr { get; set; }
        public decimal? EmplrContr { get; set; }
        public decimal? Amount { get; set; }
        public int? PeriodId { get; set; }
        public string PeriodName { get; set; }
        public bool? FlgActive { get; set; }
        public bool? FlgPaid { get; set; }
        public long? ConsumedOn { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? RetroAmount { get; set; }
        public bool? FlgRetro { get; set; }
        public bool? FlgPayroll { get; set; }
        public bool? FlgModified { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }
        public string ValueType { get; set; }
        public bool? FlgTaxable { get; set; }
        public bool? FlgStandard { get; set; }
        public bool? FlgOneTimeConsumed { get; set; }
        public string SourceType { get; set; }
        public long? SourceId { get; set; }
        public string Remarks { get; set; }

        public virtual MstElement Element { get; set; }
        public virtual TrnsEmployeeElement EmpElmt { get; set; }
        public virtual CfgPeriodDate Period { get; set; }
    }
}
