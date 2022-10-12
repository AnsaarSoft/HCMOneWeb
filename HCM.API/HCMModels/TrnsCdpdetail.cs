using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsCdpdetail
    {
        public int Id { get; set; }
        public int? HeadId { get; set; }
        public int? SkillId { get; set; }
        public string Required { get; set; }
        public string Assessed { get; set; }
        public bool? FlgTrainingProject { get; set; }
        public bool? FlgTrainingCoaching { get; set; }
        public bool? FlgTrainingInternal { get; set; }
        public bool? FlgTrainingExternal { get; set; }
        public string Justication { get; set; }
        public string Progress { get; set; }

        public virtual TrnsCdphead Head { get; set; }
        public virtual MstCompetancy Skill { get; set; }
    }
}
