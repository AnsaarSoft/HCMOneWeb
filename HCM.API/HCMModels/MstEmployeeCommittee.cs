using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstEmployeeCommittee
    {
        public int Id { get; set; }
        public int? CommitteeId { get; set; }
        public int? EmpId { get; set; }

        public virtual MstCommitteeSetup Committee { get; set; }
        public virtual MstEmployee Emp { get; set; }
    }
}
