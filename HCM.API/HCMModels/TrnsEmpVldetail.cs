using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsEmpVldetail
    {
        public long TrnsEmpVldetailId { get; set; }
        public long? TrnsEmpVlid { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public long? PeriodId { get; set; }
        public decimal? DaysCount { get; set; }
        public decimal? DaysAvailable { get; set; }
        public bool? FlgPaidOnLeave { get; set; }
        public bool? FlgTicketRequired { get; set; }
        public int? LeaveRequestId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string CreateBy { get; set; }
        public string UpdateBy { get; set; }
        public bool? FlgCanceled { get; set; }
        public bool? FlgClosed { get; set; }
        public decimal? PerDayGross { get; set; }
        public decimal? EncashValue { get; set; }

        public virtual TrnsEmpVl TrnsEmpVl { get; set; }
    }
}
