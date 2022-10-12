using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsEmployeePerPieceProcessingDetail
    {
        public int InternalId { get; set; }
        public int? Fkid { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public decimal? Rate { get; set; }
        public decimal? Qty { get; set; }
        public decimal? LineTotal { get; set; }

        public virtual TrnsEmployeePerPieceProcessing Fk { get; set; }
    }
}
