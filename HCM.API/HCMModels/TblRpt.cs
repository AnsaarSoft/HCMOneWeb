using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TblRpt
    {
        public long ReportId { get; set; }
        public string RptCode { get; set; }
        public string ReportName { get; set; }
        public byte[] RptFileStr { get; set; }
        public string ReportIn { get; set; }
        public string Critaria { get; set; }
        public bool? FlgEmployee { get; set; }
        public bool? FlgDept { get; set; }
        public bool? FlgLocation { get; set; }
        public bool? FlgDateFrom { get; set; }
        public bool? FlgDateTo { get; set; }
        public bool? FlgSystem { get; set; }
        public bool? FlgPreviousPeriod { get; set; }
        public bool? FlgPeriod { get; set; }
        public bool? FlgCritaria { get; set; }
        public bool? FlgActive { get; set; }
    }
}
