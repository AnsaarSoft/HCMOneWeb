using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class CfgAttandanceSetting
    {
        public int Id { get; set; }
        public string TimeType { get; set; }
        public string TimeValue { get; set; }
        public string MachineType { get; set; }
        public DateTime? CreateDt { get; set; }
        public DateTime? UpdateDt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdateBy { get; set; }
    }
}
