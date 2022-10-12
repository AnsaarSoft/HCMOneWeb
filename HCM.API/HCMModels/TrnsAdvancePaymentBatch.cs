using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsAdvancePaymentBatch
    {
        public TrnsAdvancePaymentBatch()
        {
            TrnsAdvancePaymentBatchDetails = new HashSet<TrnsAdvancePaymentBatchDetail>();
        }

        public int Id { get; set; }
        public decimal DocumentNo { get; set; }
        public DateTime? DocumentDate { get; set; }
        public DateTime? DurationTo { get; set; }
        public int? PayrollId { get; set; }
        public string PayrollName { get; set; }
        public int? PeriodId { get; set; }
        public string PeriodName { get; set; }
        public int? AdvanceType { get; set; }
        public string AdvanceName { get; set; }
        public string PaidAccount { get; set; }
        public string Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public virtual ICollection<TrnsAdvancePaymentBatchDetail> TrnsAdvancePaymentBatchDetails { get; set; }
    }
}
