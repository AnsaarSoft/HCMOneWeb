using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsGratuitySlabsDetail
    {
        public int InternalId { get; set; }
        public int? Fkid { get; set; }
        public string Description { get; set; }
        public decimal? FromPoints { get; set; }
        public decimal? ToPoints { get; set; }
        public decimal? DaysCount { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual TrnsGratuitySlab Fk { get; set; }
    }
}
