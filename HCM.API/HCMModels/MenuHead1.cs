using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MenuHead1
    {
        public double? Id { get; set; }
        public double? MenuId { get; set; }
        public string MenuName { get; set; }
        public double? ParentId { get; set; }
        public string Navigation { get; set; }
    }
}
