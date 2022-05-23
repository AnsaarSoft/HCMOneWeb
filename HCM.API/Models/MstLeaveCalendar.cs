using System;
using System.Collections.Generic;

namespace HCM.API.Models
{
    public partial class MstLeaveCalendar
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? FlgActive { get; set; }
    }
}
