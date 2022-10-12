using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstAttendanceAllowance
    {
        public int Id { get; set; }
        public int? DocNo { get; set; }
        public string Code { get; set; }
        public string LeaveType { get; set; }
        public int? LeaveCount { get; set; }
        public string ElementType { get; set; }
        public int? ScaleFrom { get; set; }
        public int? ScaleTo { get; set; }
        public decimal? Value { get; set; }
        public bool? FlgActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
