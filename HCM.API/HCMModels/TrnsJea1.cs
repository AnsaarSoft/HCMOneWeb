using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsJea1
    {
        public int InternalId { get; set; }
        public int? DocNum { get; set; }
        public DateTime? DocDate { get; set; }
        public DateTime? PostingDate { get; set; }
        public string Reference { get; set; }
        public string PeriodName { get; set; }
        public string CompanyCode { get; set; }
        public string DocType { get; set; }
        public string Currency { get; set; }
        public string AcctType { get; set; }
        public string Glcode { get; set; }
        public string Glindication { get; set; }
        public string AcctTypeDc { get; set; }
        public decimal? Amount { get; set; }
        public string Cccode { get; set; }
        public string Ccdesc { get; set; }
        public DateTime? ValueDate { get; set; }
        public string AcctDesc { get; set; }
        public string ProfitCenter { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreateDt { get; set; }
    }
}
