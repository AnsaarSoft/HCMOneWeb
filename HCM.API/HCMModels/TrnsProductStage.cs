using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsProductStage
    {
        public TrnsProductStage()
        {
            TrnsProductStageStations = new HashSet<TrnsProductStageStation>();
            TrnsProductStageTeamLeads = new HashSet<TrnsProductStageTeamLead>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool? Rework { get; set; }
        public bool? FlgActive { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }

        public virtual ICollection<TrnsProductStageStation> TrnsProductStageStations { get; set; }
        public virtual ICollection<TrnsProductStageTeamLead> TrnsProductStageTeamLeads { get; set; }
    }
}
