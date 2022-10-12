using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TmpVlBal
    {
        public long Id { get; set; }
        public string EmpCode { get; set; }
        public long? EmpId { get; set; }
        public DateTime? Doj { get; set; }
        public decimal? VlBalance { get; set; }
    }
}
