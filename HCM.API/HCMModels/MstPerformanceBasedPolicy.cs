using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstPerformanceBasedPolicy
    {
        public int Id { get; set; }
        public int? ServiceYear { get; set; }
        public int? PerformanceBasedBonus { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool? BasedOnGross { get; set; }
        public DateTime? EffectiveFrom { get; set; }
        public bool? Enabled { get; set; }
        public int? Pbid { get; set; }

        public virtual MstBonu Pb { get; set; }
    }
}
