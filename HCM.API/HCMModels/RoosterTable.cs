using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class RoosterTable
    {
        public int Id { get; set; }
        public string Year { get; set; }
        public DateTime? Date { get; set; }
        public string GroupA { get; set; }
        public string GroupB { get; set; }
        public string GroupC { get; set; }
        public string GroupD { get; set; }
    }
}
