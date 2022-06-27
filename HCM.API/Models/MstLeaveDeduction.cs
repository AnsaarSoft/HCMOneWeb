using System;
using System.Collections.Generic;

namespace HCM.API.Models
{
    public partial class MstLeaveDeduction
    {
        public MstLeaveDeduction()
        {
            MstLeaveTypes = new HashSet<MstLeaveType>();
        }

        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string? ValueType { get; set; }
        public decimal? Value { get; set; }
        public bool? FlgActive { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<MstLeaveType> MstLeaveTypes { get; set; }
    }
}
