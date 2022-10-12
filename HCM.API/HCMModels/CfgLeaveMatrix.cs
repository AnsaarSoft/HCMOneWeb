using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class CfgLeaveMatrix
    {
        public int Id { get; set; }
        public int? Fkelement { get; set; }
        public int? FkleaveType { get; set; }
        public bool? FlgStatus { get; set; }

        public virtual MstElement FkelementNavigation { get; set; }
        public virtual MstLeaveType FkleaveTypeNavigation { get; set; }
    }
}
