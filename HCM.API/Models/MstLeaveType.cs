using System;
using System.Collections.Generic;

namespace HCM.API.Models
{
    public partial class MstLeaveType
    {
        public MstLeaveType()
        {
            MstLeavesAllocations = new HashSet<MstLeavesAllocation>();
            TrnsObleaves = new HashSet<TrnsObleaf>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string DeductionType { get; set; }
        public int? DeductionId { get; set; }
        public int? MonthDays { get; set; }
        public bool? FlgEncash { get; set; }
        public decimal? LeaveCap { get; set; }
        public bool? FlgCarryForward { get; set; }
        public bool? FlgActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual MstLeaveDeduction Deduction { get; set; }
        public virtual ICollection<MstLeavesAllocation> MstLeavesAllocations { get; set; }
        public virtual ICollection<TrnsObleaf> TrnsObleaves { get; set; }
    }
}
