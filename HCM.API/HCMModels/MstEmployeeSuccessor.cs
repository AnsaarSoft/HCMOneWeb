using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstEmployeeSuccessor
    {
        public int Id { get; set; }
        public int? EmpId { get; set; }
        public int? SuccessorId { get; set; }
        public int? Priority { get; set; }
        public bool? FlgActive { get; set; }

        public virtual MstEmployee Emp { get; set; }
        public virtual MstEmployee Successor { get; set; }
    }
}
