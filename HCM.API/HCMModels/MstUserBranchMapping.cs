using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstUserBranchMapping
    {
        public long Id { get; set; }
        public int EmpId { get; set; }
        public int BranchId { get; set; }
        public bool? FlgActive { get; set; }
        public DateTime? AssignDate { get; set; }
        public DateTime? DeAssignDate { get; set; }
    }
}
