using System;
using System.Collections.Generic;

namespace HCM.API.Models
{
    public partial class MstLeavesAllocated
    {
        public int Id { get; set; }
        public int? EmpId { get; set; }
        public int? LeaveId { get; set; }
        public decimal LeavesAllowed { get; set; }
        public decimal LeavesUsed { get; set; }
        public decimal LeavesEntitled { get; set; }
        public decimal LeavesCarryForward { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string CalCode { get; set; } = null!;
        public bool? FlgCarryForward { get; set; }
        public DateTime? CarryForwardDate { get; set; }
        public bool? FlgLeaveCollapse { get; set; }
        public DateTime? LeaveCollapseDate { get; set; }
        public bool? FlgActive { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual MstLeaveType? Leave { get; set; }
    }
}
