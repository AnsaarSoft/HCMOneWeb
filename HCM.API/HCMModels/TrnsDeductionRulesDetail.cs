using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsDeductionRulesDetail
    {
        public int Id { get; set; }
        public int? Fkid { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        public string RangeFrom { get; set; }
        public string RangeTo { get; set; }
        public bool? Deduction { get; set; }
        public int? LeaveType { get; set; }
        public int? GracePeriod { get; set; }
        public decimal? LeaveCount { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public virtual TrnsDeductionRule Fk { get; set; }
    }
}
