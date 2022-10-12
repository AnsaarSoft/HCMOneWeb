using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MenuDatum
    {
        public int Id { get; set; }
        public int? EmpId { get; set; }
        public int? MenuId { get; set; }
        public string Anthorization { get; set; }
    }
}
