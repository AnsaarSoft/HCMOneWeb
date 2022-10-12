using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class CompetencyLevelSetup
    {
        public CompetencyLevelSetup()
        {
            MstCompetancies = new HashSet<MstCompetancy>();
            MstDesigLinkCompetencies = new HashSet<MstDesigLinkCompetency>();
        }

        public int Id { get; set; }
        public string CompetencyLevelCode { get; set; }
        public string CompetencyLevelName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool? FlgActive { get; set; }

        public virtual ICollection<MstCompetancy> MstCompetancies { get; set; }
        public virtual ICollection<MstDesigLinkCompetency> MstDesigLinkCompetencies { get; set; }
    }
}
