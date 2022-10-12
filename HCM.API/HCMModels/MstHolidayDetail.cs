using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstHolidayDetail
    {
        public int Id { get; set; }
        public int Hid { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Remarks { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }

        public virtual MstHoliday HidNavigation { get; set; }
    }
}
