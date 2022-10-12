using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstEmployeeLeaf
    {
        public int Id { get; set; }
        public int? EmpId { get; set; }
        public int? CalId { get; set; }
        public string LeaveCalCode { get; set; }
        public int? LeaveType { get; set; }
        public string LeaveTypeCode { get; set; }
        public string LeaveTypeDescription { get; set; }
        public decimal LeavesEntitled { get; set; }
        public decimal LeavesCarryForward { get; set; }
        public decimal LeavesUsed { get; set; }
        public decimal? LeaveBalance { get; set; }
        public bool? FlgCarryForward { get; set; }
        public DateTime? CarryForwardDate { get; set; }
        public bool? FlgLeaveCollapse { get; set; }
        public DateTime? LeaveCollapseDate { get; set; }
        public string Source { get; set; }
        public bool? FlgActive { get; set; }
        public decimal LeavesAllowed { get; set; }
        public DateTime? FromDt { get; set; }
        public DateTime? ToDt { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string CreatedBy { get; set; }

        public virtual MstEmployee Emp { get; set; }
        public virtual MstLeaveType LeaveTypeNavigation { get; set; }
    }
}
