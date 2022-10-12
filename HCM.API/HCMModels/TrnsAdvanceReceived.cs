using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsAdvanceReceived
    {
        public int Id { get; set; }
        public int? AdvanceId { get; set; }
        public int? DocEntry { get; set; }
        public int? EmpId { get; set; }
        public string EmpName { get; set; }
        public decimal? ReceivedAmount { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
