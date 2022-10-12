using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstCommitmentAllowancePolicy
    {
        public int Id { get; set; }
        public int? CommitmentAllowancePercentage { get; set; }
        public bool? BasedOnGross { get; set; }
        public int? ReturnFundMonths { get; set; }
        public DateTime? EffectiveFrom { get; set; }
        public bool? Enabled { get; set; }
        public string Createdby { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
