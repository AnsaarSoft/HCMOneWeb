using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstEmployeeCodeSeries
    {
        public int Id { get; set; }
        public int? BranchId { get; set; }
        public string BranchName { get; set; }
        public string StartNumber { get; set; }
        public string EndNumber { get; set; }
        public string Prefix { get; set; }
        public string StartPrefixSeries { get; set; }
        public string EndPrefixSeries { get; set; }
        public string SNum { get; set; }
        public string ENum { get; set; }
        public bool? FlgActive { get; set; }
        public string NextAvailableCode { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
