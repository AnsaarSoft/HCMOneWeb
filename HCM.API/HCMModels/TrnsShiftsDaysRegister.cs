using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsShiftsDaysRegister
    {
        public int InternalId { get; set; }
        public string EmpCode { get; set; }
        public string EmpName { get; set; }
        public DateTime? RecordDate { get; set; }
        public string ShiftName { get; set; }
        public int? DayStatus { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
