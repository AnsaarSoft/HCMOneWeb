using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class AttDevUser
    {
        public long DevUsrId { get; set; }
        public int? DeviceId { get; set; }
        public string EnrollNum { get; set; }
        public DateTime? ReadDat { get; set; }
        public string DevIp { get; set; }
        public string EmpName { get; set; }
        public string Pwd { get; set; }
        public string Enabled { get; set; }
        public string UserTemplate { get; set; }

        public virtual AttDevice Device { get; set; }
    }
}
