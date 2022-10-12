using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstAppraisal
    {
        public int Id { get; set; }
        public int? Year { get; set; }
        public string IncrementPercent { get; set; }
        public string Createdby { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string WppfAmount { get; set; }
        public string CategoryA { get; set; }
        public string CategoryB { get; set; }
        public string CategoryC { get; set; }
        public string CategoryD { get; set; }
        public string TenC { get; set; }
    }
}
