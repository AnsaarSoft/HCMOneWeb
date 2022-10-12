using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsDeptShiftDetail
    {
        public int Id { get; set; }
        public int? DeptShiftId { get; set; }
        public int? ShiftForId { get; set; }
        public int? SunShift { get; set; }
        public int? MonShift { get; set; }
        public int? TueShift { get; set; }
        public int? WedShift { get; set; }
        public int? ThuShift { get; set; }
        public int? FriShift { get; set; }
        public int? SatShift { get; set; }

        public virtual TrnsDeptShift DeptShift { get; set; }
    }
}
