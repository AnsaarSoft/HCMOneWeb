using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsEmployeePerPieceRateDetail
    {
        public int InternalId { get; set; }
        public int? Fkid { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public decimal? Rate { get; set; }
        public bool? FlgActive { get; set; }
        public bool? FlgDelete { get; set; }
        public DateTime? CreatedDt { get; set; }
        public DateTime? UpdatedDt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public virtual TrnsEmployeePerPieceRate Fk { get; set; }
    }
}
