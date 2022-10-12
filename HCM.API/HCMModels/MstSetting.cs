using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstSetting
    {
        public int Id { get; set; }
        public bool FlgRptCeo { get; set; }
        public int Year { get; set; }
        public int Term { get; set; }
    }
}
