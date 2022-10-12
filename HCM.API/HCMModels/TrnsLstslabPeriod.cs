using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsLstslabPeriod
    {
        public int InternalId { get; set; }
        public int? Fkid { get; set; }
        public string PaidMonths { get; set; }
        public bool? FlgActive { get; set; }

        public virtual TrnsLstslab Fk { get; set; }
    }
}
