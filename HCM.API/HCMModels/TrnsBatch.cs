using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsBatch
    {
        public TrnsBatch()
        {
            TrnsBatchesDetails = new HashSet<TrnsBatchesDetail>();
        }

        public int Id { get; set; }
        public string BatchName { get; set; }
        public int? PayrollId { get; set; }
        public int? PayrollPeriodId { get; set; }
        public string PayrollName { get; set; }
        public string PayrollPeriod { get; set; }
        public int? ElementId { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public long? IfExist { get; set; }
        public long? BatchStatus { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }
        public string ElmtCode { get; set; }
        public string ElmtName { get; set; }
        public string ElmtType { get; set; }
        public string ValType { get; set; }
        public decimal? Value { get; set; }
        public decimal? EmplrCont { get; set; }
        public int? DocNum { get; set; }
        public int? DocType { get; set; }
        public string DocStatus { get; set; }
        public string DocAprStatus { get; set; }
        public string Remarks { get; set; }

        public virtual MstElement Element { get; set; }
        public virtual CfgPayrollDefination Payroll { get; set; }
        public virtual CfgPeriodDate PayrollPeriodNavigation { get; set; }
        public virtual ICollection<TrnsBatchesDetail> TrnsBatchesDetails { get; set; }
    }
}
