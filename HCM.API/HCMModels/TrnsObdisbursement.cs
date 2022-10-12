using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsObdisbursement
    {
        public int Id { get; set; }
        public int? EmpId { get; set; }
        public decimal? SalaryAmount { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
