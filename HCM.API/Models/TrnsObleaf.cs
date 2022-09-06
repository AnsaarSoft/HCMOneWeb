using System;
using System.Collections.Generic;

namespace HCM.API.Models
{
    public partial class TrnsObleaf
    {
        public int Id { get; set; }
        public int? EmpId { get; set; }
        public int? Fkid { get; set; }
        public decimal? LeavesCarryForward { get; set; }
        public decimal? LeavesEntitled { get; set; }
        public decimal? LeaveUsed { get; set; }
        public int CalId { get; set; }
        public string CalCode { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual MstLeaveType Fk { get; set; }
    }
}
