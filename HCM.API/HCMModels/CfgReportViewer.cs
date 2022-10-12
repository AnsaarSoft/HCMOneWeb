using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class CfgReportViewer
    {
        public int Id { get; set; }
        public bool? EnableWebReport { get; set; }
        public string WebReportServerUrl { get; set; }
    }
}
