using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsPartnerUnAllocatedFormsDetail
    {
        public int Id { get; set; }
        public int? HeadId { get; set; }
        public int? PartnerId { get; set; }
        public decimal? PartnerPercent { get; set; }
        public decimal? Total { get; set; }

        public virtual TrnsPartnerUnAllocatedFormsHead Head { get; set; }
        public virtual MstEmployee Partner { get; set; }
    }
}
