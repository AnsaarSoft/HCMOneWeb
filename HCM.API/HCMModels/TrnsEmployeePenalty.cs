using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsEmployeePenalty
    {
        public int Id { get; set; }
        public int? EmpId { get; set; }
        public int? PenaltyId { get; set; }
        public int? Days { get; set; }
        public int? PenaltyDays { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public bool? FlgActive { get; set; }

        public virtual MstEmployee Emp { get; set; }
        public virtual MstPenaltyRule Penalty { get; set; }
    }
}
