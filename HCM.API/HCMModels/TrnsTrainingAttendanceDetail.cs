using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsTrainingAttendanceDetail
    {
        public TrnsTrainingAttendanceDetail()
        {
            TrnsTrainingAttendanceAttachments = new HashSet<TrnsTrainingAttendanceAttachment>();
        }

        public int Id { get; set; }
        public int? AttendanceId { get; set; }
        public int? EmpId { get; set; }
        public bool? FlgAttended { get; set; }
        public string Remarks { get; set; }
        public decimal? TrainingHours { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public virtual TrnsTrainingAttendance Attendance { get; set; }
        public virtual MstEmployee Emp { get; set; }
        public virtual ICollection<TrnsTrainingAttendanceAttachment> TrnsTrainingAttendanceAttachments { get; set; }
    }
}
