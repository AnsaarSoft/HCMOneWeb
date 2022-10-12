using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsEmpElementHead
    {
        public TrnsEmpElementHead()
        {
            TrnsEmployeeElementDetail1s = new HashSet<TrnsEmployeeElementDetail1>();
            TrnsEmployeeHirings = new HashSet<TrnsEmployeeHiring>();
        }

        public int HeadId { get; set; }
        public string Description { get; set; }
        public int? EmpId { get; set; }

        public virtual ICollection<TrnsEmployeeElementDetail1> TrnsEmployeeElementDetail1s { get; set; }
        public virtual ICollection<TrnsEmployeeHiring> TrnsEmployeeHirings { get; set; }
    }
}
