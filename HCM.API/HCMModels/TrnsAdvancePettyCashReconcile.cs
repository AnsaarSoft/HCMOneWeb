using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsAdvancePettyCashReconcile
    {
        public int Id { get; set; }
        public int? EmpId { get; set; }
        public int? RequestDocId { get; set; }
        public int? ClaimDocId { get; set; }
        public string DocumentType { get; set; }
        public decimal? Amount { get; set; }
        public string CalCode { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }
        public bool? FlgProcessInPayroll { get; set; }
        public int? Sboid { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
