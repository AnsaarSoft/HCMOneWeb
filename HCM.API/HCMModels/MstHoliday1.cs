using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstHoliday1
    {
        public MstHoliday1()
        {
            MstHolidayDetails = new HashSet<MstHolidayDetail>();
        }

        public int Id { get; set; }
        public string Holiday { get; set; }
        public string HolidayName { get; set; }
        public bool? FlgActive { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }
        public string WeekNumbering { get; set; }
        public string WeekendFrom { get; set; }
        public string WeekendTo { get; set; }
        public bool? Validity { get; set; }
        public bool? WeekendAtWork { get; set; }

        public virtual ICollection<MstHolidayDetail> MstHolidayDetails { get; set; }
    }
}
