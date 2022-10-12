using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsNotificaiotnApprovalSystem
    {
        public int Id { get; set; }
        public int? EmpId { get; set; }
        public int? NotificationCategoryId { get; set; }
        public int? DurationsDays { get; set; }
        public int? DuratinsMonth { get; set; }
        public string Description { get; set; }
        public DateTime? DateForm { get; set; }
        public DateTime? DateTo { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public bool? FlgActive { get; set; }

        public virtual MstEmployee Emp { get; set; }
        public virtual MstNoficationCategory NotificationCategory { get; set; }
    }
}
