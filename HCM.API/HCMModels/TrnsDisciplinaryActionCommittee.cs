using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsDisciplinaryActionCommittee
    {
        public int Id { get; set; }
        public int? ActionHeadId { get; set; }
        public int? EmployeeId { get; set; }

        public virtual TrnsDisciplinaryActionRequest ActionHead { get; set; }
        public virtual MstEmployee Employee { get; set; }
    }
}
