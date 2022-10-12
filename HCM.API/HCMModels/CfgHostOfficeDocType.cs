using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class CfgHostOfficeDocType
    {
        public int DocId { get; set; }
        public string DocType { get; set; }
        public bool? FlgActive { get; set; }
    }
}
