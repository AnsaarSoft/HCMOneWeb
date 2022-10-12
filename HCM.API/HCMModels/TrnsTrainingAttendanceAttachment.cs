using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsTrainingAttendanceAttachment
    {
        public int Id { get; set; }
        public int? AttendanceId { get; set; }
        public int? AttedanceDetailId { get; set; }
        public int? TrainingPlanId { get; set; }
        public bool? IsHr { get; set; }
        public string DocName { get; set; }
        public string Extension { get; set; }
        public string DocContent { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool? FlgActive { get; set; }
        public bool? Deleted { get; set; }

        public virtual TrnsTrainingAttendanceDetail AttedanceDetail { get; set; }
        public virtual TrnsTrainingAttendance Attendance { get; set; }
        public virtual TrnsTrainingPlan TrainingPlan { get; set; }
    }
}
