using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsRejectedObj
    {
        public int Id { get; set; }
        public int DeptId { get; set; }
        public DateTime? RejectedDate { get; set; }
        public bool? FlgActive { get; set; }
        public int Year { get; set; }
        public int Term { get; set; }
    }
}
