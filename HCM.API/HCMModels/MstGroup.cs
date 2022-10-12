using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstGroup
    {
        public int Id { get; set; }
        public int Groupid { get; set; }
        public string GroupName { get; set; }
        public string GroupDescription { get; set; }
    }
}
