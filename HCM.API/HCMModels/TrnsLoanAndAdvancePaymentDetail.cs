using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsLoanAndAdvancePaymentDetail
    {
        public int Id { get; set; }
        public int? LapaymentId { get; set; }
        public string Glaccount { get; set; }
        public string Glname { get; set; }
        public string DocumentRemarks { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }

        public virtual TrnsLoanAndAdvancePayment Lapayment { get; set; }
    }
}
