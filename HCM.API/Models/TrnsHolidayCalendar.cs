using System;
using System.Collections.Generic;

namespace HCM.API.Models
{
    public partial class TrnsHolidayCalendar
    {
        public TrnsHolidayCalendar()
        {
            TrnsHolidayCalendarDetails = new HashSet<TrnsHolidayCalendarDetail>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string CalCode { get; set; }

        public virtual ICollection<TrnsHolidayCalendarDetail> TrnsHolidayCalendarDetails { get; set; }
    }
}
