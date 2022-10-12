using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsPartnerBusinessRevenueDetail
    {
        public int Id { get; set; }
        public int? BusinessRevenueId { get; set; }
        public string PartnerName { get; set; }
        public int? PartnerId { get; set; }
        public decimal? NewBusinessAmnt { get; set; }
        public decimal? PositiveNumbers { get; set; }
        public decimal? PartnerPercent { get; set; }
        public decimal? Total { get; set; }

        public virtual TrnsPartnerBusinessRevenue BusinessRevenue { get; set; }
        public virtual MstEmployee Partner { get; set; }
    }
}
