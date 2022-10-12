using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsVlEntitlement
    {
        public long TrnsVlEntId { get; set; }
        public long? TrnsEmpVlid { get; set; }
        public int? PeriodId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public decimal? Entitlments { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string CreateBy { get; set; }
        public string UpdateBy { get; set; }

        public virtual TrnsEmpVl TrnsEmpVl { get; set; }
    }
}
