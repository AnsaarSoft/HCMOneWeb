using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class CfgDbhostOffice
    {
        public int HostOfficeId { get; set; }
        public string HostOfficeName { get; set; }
        public bool? FlgActive { get; set; }
    }
}
