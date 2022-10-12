using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstDeductionRuleSup
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        public string RangeFrom { get; set; }
        public string RangeTo { get; set; }
        public bool? Deduction { get; set; }
        public int? LeaveType { get; set; }
    }
}
