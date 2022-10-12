using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstAttendanceAutoSaveConfiguration
    {
        public int Id { get; set; }
        public string StartTime { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
