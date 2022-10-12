using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsPartnerRevenueAccrualDetail
    {
        public int Id { get; set; }
        public int? RevenueAccId { get; set; }
        public string PartnerName { get; set; }
        public int? PartnerId { get; set; }
        public decimal? Revenue { get; set; }
        public decimal? PositiveNumbers { get; set; }
        public decimal? PartnerPercent { get; set; }
        public decimal? Total { get; set; }

        public virtual MstEmployee Partner { get; set; }
        public virtual TrnsPartnerRevenueAccrual RevenueAcc { get; set; }
    }
}
