using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstPartnerPerformanceTerm
    {
        public int Id { get; set; }
        public int? YearId { get; set; }
        public string TermDescription { get; set; }
        public bool? FlgActive { get; set; }
        public DateTime? AvailableForAvailuation { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? NotificationDaysForPartner { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual MstCalendar Year { get; set; }
    }
}
