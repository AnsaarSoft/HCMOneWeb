using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstMenuList
    {
        public int Id { get; set; }
        public string Menu { get; set; }
        public int Level { get; set; }
        public string FormLogicalName { get; set; }
        public bool? IsMenuItem { get; set; }
        public bool? IsActive { get; set; }
        public string FormLogicalNameAr { get; set; }
    }
}
