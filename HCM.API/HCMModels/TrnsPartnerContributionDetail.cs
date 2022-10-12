using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsPartnerContributionDetail
    {
        public int Id { get; set; }
        public int? ContributionId { get; set; }
        public string PartnerName { get; set; }
        public int? PartnerId { get; set; }
        public decimal? BonusPool { get; set; }
        public decimal? PositiveNumbers { get; set; }
        public decimal? PartnerPercent { get; set; }
        public decimal? Total { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }

        public virtual TrnsPartnerContributionPool Contribution { get; set; }
        public virtual MstEmployee Partner { get; set; }
    }
}
