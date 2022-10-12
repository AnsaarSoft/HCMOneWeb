using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsPayeslabDetail
    {
        public int InternalId { get; set; }
        public int? Fkid { get; set; }
        public decimal? MinValue { get; set; }
        public decimal? MaxValue { get; set; }
        public decimal? FixValue { get; set; }
        public decimal? PerValue { get; set; }
        public decimal? UpperCap { get; set; }
        public decimal? ExceededPercentage { get; set; }
        public bool? FlgActive { get; set; }

        public virtual TrnsPayeslab Fk { get; set; }
    }
}
