using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsAdvancePettyCashClaimsDetail
    {
        public int Id { get; set; }
        public int? EmpId { get; set; }
        public string Refernce { get; set; }
        public string Remarks { get; set; }
        public DateTime? ClaimDate { get; set; }
        public decimal? ClaimAmount { get; set; }
        public decimal? Reconsiled { get; set; }
        public int? Sboid { get; set; }
        public string CalCode { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string AccountCode { get; set; }
        public string AccountName { get; set; }
    }
}
