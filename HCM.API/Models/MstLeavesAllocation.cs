using System;
using System.Collections.Generic;

namespace HCM.API.Models
{
    public partial class MstLeavesAllocation
    {
        public int Id { get; set; }
        public int EmpId { get; set; }
        public int? Fkid { get; set; }
        public decimal LeavesCarryForward { get; set; }
        public decimal LeavesEntitled { get; set; }
        public decimal LeavesUsed { get; set; }
        public decimal? LeaveBalance { get; set; }
        public int CalId { get; set; }
        public string CalCode { get; set; }
        public bool? FlgCarryForward { get; set; }
        public DateTime? CarryForwardDate { get; set; }
        public bool? FlgLeaveCollapse { get; set; }
        public DateTime? LeaveCollapseDate { get; set; }
        public bool? FlgActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual MstLeaveType Fk { get; set; }
    }
}
