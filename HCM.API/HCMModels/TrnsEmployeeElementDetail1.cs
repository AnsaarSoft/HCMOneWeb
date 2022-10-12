using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsEmployeeElementDetail1
    {
        public int Id { get; set; }
        public int? ElementId { get; set; }
        public int? HeadId { get; set; }

        public virtual MstElement Element { get; set; }
        public virtual TrnsEmpElementHead Head { get; set; }
    }
}
