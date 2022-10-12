using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstGratuityDetail
    {
        public int Id { get; set; }
        public int? GratId { get; set; }
        public string Description { get; set; }
        public decimal? FromPoints { get; set; }
        public decimal? ToPoints { get; set; }
        public decimal? DaysCount { get; set; }
        public int? FromYear { get; set; }
        public int? ToYear { get; set; }
        public decimal? Factor { get; set; }
        public decimal? FactorRes { get; set; }
        public decimal? FactorTerm { get; set; }
        public decimal? FactorContractEnd { get; set; }

        public virtual MstGratuity Grat { get; set; }
    }
}
