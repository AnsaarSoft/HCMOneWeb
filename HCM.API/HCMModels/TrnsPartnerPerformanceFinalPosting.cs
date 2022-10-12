using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsPartnerPerformanceFinalPosting
    {
        public int Id { get; set; }
        public int? CategoryId { get; set; }
        public int? PartnerId { get; set; }
        public decimal? WeightageSumBefore { get; set; }
        public decimal? WeightageSumAfter { get; set; }
        public decimal? WeightageAllocation { get; set; }
        public bool? FlgActive { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual MstPartnerPerformanceCategory Category { get; set; }
    }
}
