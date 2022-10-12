using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstPenaltyRule
    {
        public MstPenaltyRule()
        {
            TrnsEmployeePenalties = new HashSet<TrnsEmployeePenalty>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int? Days { get; set; }
        public int? PenaltyDays { get; set; }
        public int? LeaveType { get; set; }

        public virtual ICollection<TrnsEmployeePenalty> TrnsEmployeePenalties { get; set; }
    }
}
