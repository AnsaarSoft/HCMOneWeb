using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class RoosterInput
    {
        public int Id { get; set; }
        public string Year { get; set; }
        public string GroupName { get; set; }
        public string Shift { get; set; }
        public DateTime? Date { get; set; }
    }
}
