using System;
using System.Collections.Generic;

namespace HCM.API.Models
{
    public partial class MstPayrollElement
    {
        public int Id { get; set; }
        public int? Fkid { get; set; }
        public int? ElementId { get; set; }
        public bool? FlgActive { get; set; }

        public virtual MstPayroll? Fk { get; set; }
    }
}
