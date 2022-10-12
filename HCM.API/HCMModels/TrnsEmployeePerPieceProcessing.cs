using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsEmployeePerPieceProcessing
    {
        public TrnsEmployeePerPieceProcessing()
        {
            TrnsEmployeePerPieceProcessingDetails = new HashSet<TrnsEmployeePerPieceProcessingDetail>();
        }

        public int InternalId { get; set; }
        public int? EmpId { get; set; }
        public string EmpName { get; set; }
        public int? PayrollId { get; set; }
        public string PayrollName { get; set; }
        public int? PeriodId { get; set; }
        public string PeriodName { get; set; }
        public decimal? NetPayable { get; set; }
        public bool? FlgProcessed { get; set; }
        public bool? FlgPosted { get; set; }
        public int? Jenum { get; set; }
        public string DebitAccount { get; set; }
        public string DebitName { get; set; }
        public string CreditAccount { get; set; }
        public string CreditName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreateDt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UdateDt { get; set; }

        public virtual MstEmployee Emp { get; set; }
        public virtual CfgPayrollDefination Payroll { get; set; }
        public virtual CfgPeriodDate Period { get; set; }
        public virtual ICollection<TrnsEmployeePerPieceProcessingDetail> TrnsEmployeePerPieceProcessingDetails { get; set; }
    }
}
