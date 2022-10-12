using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsLstslabDetail
    {
        public int InternalId { get; set; }
        public int? Fkid { get; set; }
        public decimal? MinValue { get; set; }
        public decimal? MaxValue { get; set; }
        public decimal? Amount { get; set; }
        public bool? FlgActive { get; set; }

        public virtual TrnsLstslab Fk { get; set; }
    }
}
