using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstKpirule
    {
        public int Id { get; set; }
        public int MinBasicKpicount { get; set; }
        public int MaxBasicKpicount { get; set; }
        public int MindeptKpicount { get; set; }
        public int MaxdeptKpicount { get; set; }
        public decimal BasicKpipercent { get; set; }
        public decimal DeptKpipercent { get; set; }
    }
}
