using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsObleaf
    {
        public int Id { get; set; }
        public int? LeaveId { get; set; }
        public int? EmpId { get; set; }
        public decimal? LeavesCarryForward { get; set; }
        public decimal? LeavesEntitled { get; set; }
        public decimal? LeaveUsed { get; set; }
        public int CalId { get; set; }
        public string CalCode { get; set; }
        public decimal? LeaveBalance { get; set; }
        public decimal? LeaveAllowance { get; set; }
        public DateTime? Month { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }

        public virtual MstEmployee Emp { get; set; }
        public virtual MstLeaveType Leave { get; set; }
    }
}
