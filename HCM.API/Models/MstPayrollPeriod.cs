using System;
using System.Collections.Generic;

namespace HCM.API.Models
{
    public partial class MstPayrollPeriod
    {
        public int Id { get; set; }
        public int? Fkid { get; set; }
        public string? PeriodName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? CalCode { get; set; }
        public bool? FlgLocked { get; set; }
        public bool? FlgPosted { get; set; }
        public bool? FlgVisible { get; set; }

        public virtual MstPayroll? Fk { get; set; }
    }
}
