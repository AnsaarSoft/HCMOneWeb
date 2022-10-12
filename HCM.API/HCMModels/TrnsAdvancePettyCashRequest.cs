using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsAdvancePettyCashRequest
    {
        public int Id { get; set; }
        public int? DocNum { get; set; }
        public int? EmpId { get; set; }
        public string EmpName { get; set; }
        public decimal? Salary { get; set; }
        public int? DocumentType { get; set; }
        public decimal? RequestedAmount { get; set; }
        public DateTime? RequestedDate { get; set; }
        public decimal? ClaimAmount { get; set; }
        public int? Sboid { get; set; }
        public string CalCode { get; set; }
        public string Status { get; set; }
        public bool? FlgPaid { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
