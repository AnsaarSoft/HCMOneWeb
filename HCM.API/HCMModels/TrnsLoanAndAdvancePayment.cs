using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsLoanAndAdvancePayment
    {
        public TrnsLoanAndAdvancePayment()
        {
            TrnsLoanAndAdvancePaymentDetails = new HashSet<TrnsLoanAndAdvancePaymentDetail>();
        }

        public int Id { get; set; }
        public short DocType { get; set; }
        public short? Series { get; set; }
        public int? EmpId { get; set; }
        public DateTime? MaturityDate { get; set; }
        public string Latype { get; set; }
        public int? LoadAdvanceId { get; set; }
        public string Manager { get; set; }
        public short? NoOfInstallments { get; set; }
        public bool? FlgAccount { get; set; }
        public bool? FlgBank { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }

        public virtual MstEmployee Emp { get; set; }
        public virtual ICollection<TrnsLoanAndAdvancePaymentDetail> TrnsLoanAndAdvancePaymentDetails { get; set; }
    }
}
