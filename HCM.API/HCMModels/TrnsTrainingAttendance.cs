using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsTrainingAttendance
    {
        public TrnsTrainingAttendance()
        {
            TrnsTrainingAttendanceAttachments = new HashSet<TrnsTrainingAttendanceAttachment>();
            TrnsTrainingAttendanceDetails = new HashSet<TrnsTrainingAttendanceDetail>();
        }

        public int Id { get; set; }
        public int? TrainingPlanId { get; set; }
        public bool? FlgAttended { get; set; }
        public DateTime? AttendanceDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public int? EmpId { get; set; }
        public bool? IsHr { get; set; }

        public virtual MstEmployee Emp { get; set; }
        public virtual TrnsTrainingPlan TrainingPlan { get; set; }
        public virtual ICollection<TrnsTrainingAttendanceAttachment> TrnsTrainingAttendanceAttachments { get; set; }
        public virtual ICollection<TrnsTrainingAttendanceDetail> TrnsTrainingAttendanceDetails { get; set; }
    }
}
