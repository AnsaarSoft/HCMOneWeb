using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstDesigLinkCompetency
    {
        public int Id { get; set; }
        public int? CompetencySetupId { get; set; }
        public int? CompetencyLevelId { get; set; }
        public int? DesignationId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public bool? FlgActive { get; set; }

        public virtual CompetencyLevelSetup CompetencyLevel { get; set; }
        public virtual MstCompetancy CompetencySetup { get; set; }
        public virtual MstDesignation Designation { get; set; }
    }
}
