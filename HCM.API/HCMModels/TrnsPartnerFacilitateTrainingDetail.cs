using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsPartnerFacilitateTrainingDetail
    {
        public int Id { get; set; }
        public int? HeadId { get; set; }
        public int? PartnerId { get; set; }
        public decimal? TrainerHours { get; set; }
        public decimal? PositiveNumbers { get; set; }
        public decimal? PartnerPercent { get; set; }
        public decimal? Total { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }

        public virtual TrnsPartnerFacilitateTrainingHead Head { get; set; }
        public virtual MstEmployee Partner { get; set; }
    }
}
