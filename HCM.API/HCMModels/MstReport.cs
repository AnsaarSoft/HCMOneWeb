using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstReport
    {
        public int Id { get; set; }
        public string ReportCode { get; set; }
        public string ReportName { get; set; }
        public bool? FlgLayout { get; set; }
        public string ReportDoc { get; set; }
        public string FilePath { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool? FlgActive { get; set; }
        public bool? FlgDelete { get; set; }
    }
}
