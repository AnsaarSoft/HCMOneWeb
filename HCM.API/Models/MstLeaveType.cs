using System;
using System.Collections.Generic;

namespace HCM.API.Models
{
    public partial class MstLeaveType
    {
        public MstLeaveType()
        {
            MstLeavesAllocateds = new HashSet<MstLeavesAllocated>();
        }

        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string? LeaveType { get; set; }
        public int? DeductionId { get; set; }
        public int? MonthDays { get; set; }
        public bool? FlgEncash { get; set; }
        public decimal? LeaveCap { get; set; }
        public bool? FlgCarryForward { get; set; }
        public bool? FlgActive { get; set; }

        public virtual MstLeaveDeduction? Deduction { get; set; }
        public virtual ICollection<MstLeavesAllocated> MstLeavesAllocateds { get; set; }
    }
}
