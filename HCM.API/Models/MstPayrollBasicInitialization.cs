using System;
using System.Collections.Generic;

namespace HCM.API.Models
{
    public partial class MstPayrollBasicInitialization
    {
        public int Id { get; set; }
        public string? CompanyName { get; set; }
        public bool? Sapb1integration { get; set; }
        public bool? FlgAttendanceSystem { get; set; }
        public bool? FlgProcessingOnAttendance { get; set; }
        public bool? FlgAbsent { get; set; }
        public bool? FlgTaxSetup { get; set; }
        public bool? FlgLeaveCalendar { get; set; }
        public bool? FlgLateInEarlyOutLeaveRules { get; set; }
        public bool? FlgMultipleDimension { get; set; }
        public bool? FlgEmployeeCodeSeries { get; set; }
    }
}
