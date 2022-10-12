using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsAttendancePosted
    {
        public int Id { get; set; }
        public string EmpId { get; set; }
        public int? PayrollId { get; set; }
        public int? PeriodId { get; set; }
        public int? PresentDays { get; set; }
        public bool? FlgApplicableDays { get; set; }
        public string Day { get; set; }
        public DateTime? Date { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
