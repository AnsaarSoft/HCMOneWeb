using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsOvertime
    {
        public int Id { get; set; }
        public string EmpCode { get; set; }
        public int? OverTimeDays { get; set; }
        public decimal? OverTimeHours { get; set; }
        public string PeriodCode { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
