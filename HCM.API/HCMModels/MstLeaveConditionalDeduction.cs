using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstLeaveConditionalDeduction
    {
        public int Id { get; set; }
        public int? LeaveCount { get; set; }
        public string NonDeductableLeave { get; set; }
        public string DeductableLeave { get; set; }
        public int? Periorty { get; set; }
        public bool? FlgActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
