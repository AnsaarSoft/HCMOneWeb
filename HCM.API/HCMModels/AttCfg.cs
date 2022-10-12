using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class AttCfg
    {
        public long Id { get; set; }
        public string EmailAddress { get; set; }
        public int? RecycleIntervel { get; set; }
        public int? ReadTimeOut { get; set; }
        public int? ConnectionTimeOut { get; set; }
        public bool? FlgOnStart { get; set; }
    }
}
