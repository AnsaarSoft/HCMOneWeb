using System;
using System.Collections.Generic;

namespace HCM.API.Models
{
    public partial class TrnsHolidayCalendarDetail
    {
        public int Id { get; set; }
        public int Fkid { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual TrnsHolidayCalendar Fk { get; set; }
    }
}
