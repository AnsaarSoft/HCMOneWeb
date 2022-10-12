using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsPartnerNetProfitDetail
    {
        public int Id { get; set; }
        public int? NetProfitId { get; set; }
        public string PartnerName { get; set; }
        public int? PartnerId { get; set; }
        public decimal? NetProfit { get; set; }
        public decimal? PositiveNumbers { get; set; }
        public decimal? PartnerPercent { get; set; }
        public decimal? Total { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }

        public virtual TrnsPartnerNetProfit NetProfitNavigation { get; set; }
        public virtual MstEmployee Partner { get; set; }
    }
}
