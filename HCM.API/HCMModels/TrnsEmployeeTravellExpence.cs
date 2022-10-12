using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsEmployeeTravellExpence
    {
        public int Id { get; set; }
        public int? DocNum { get; set; }
        public int? EmpId { get; set; }
        public int? PayrollMonthId { get; set; }
        public DateTime? DocDate { get; set; }
        public string DocDay { get; set; }
        public string FromCity { get; set; }
        public string ToCity { get; set; }
        public decimal? Km { get; set; }
        public decimal? Charges { get; set; }
        public decimal? OutBack { get; set; }
        public decimal? NightStay { get; set; }
        public decimal? Other { get; set; }
        public decimal? Total { get; set; }
        public string Remarks { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
