using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsSduae
    {
        public int Id { get; set; }
        public int? PayrollId { get; set; }
        public string PayrollName { get; set; }
        public int? PeriodId { get; set; }
        public string PeriodName { get; set; }
        public string PaymentType { get; set; }
        public string PaymentMode { get; set; }
        public string PaymentAccounts { get; set; }
        public string PaidAccount { get; set; }
        public int? Jeid { get; set; }
        public string Jedescription { get; set; }
        public decimal? DisburseAmount { get; set; }
        public int? Sbojeid { get; set; }
        public int? Sboopid { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
