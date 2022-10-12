using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class AttScan
    {
        public long LogId { get; set; }
        public string EnrolmentId { get; set; }
        public DateTime? ScanDt { get; set; }
        public string Verify { get; set; }
        public string Io { get; set; }
        public string WorkCode { get; set; }
        public DateTime? FatchDt { get; set; }
        public string DeviceIp { get; set; }
        public string DeviceDept { get; set; }
    }
}
