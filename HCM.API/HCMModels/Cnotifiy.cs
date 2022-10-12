using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class Cnotifiy
    {
        public int Id { get; set; }
        public int? DocType { get; set; }
        public int? DocId { get; set; }
        public int? EmpId { get; set; }
        public string Status { get; set; }
        public bool? FlgActive { get; set; }
    }
}
