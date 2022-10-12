using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstCompetancy
    {
        public MstCompetancy()
        {
            MstDesigLinkCompetencies = new HashSet<MstDesigLinkCompetency>();
            TrnsCdpdetails = new HashSet<TrnsCdpdetail>();
            TrnsJrdetailCompetancies = new HashSet<TrnsJrdetailCompetancy>();
        }

        public int Id { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }
        public bool? FlgActive { get; set; }
        public int? CompetencyLevelId { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }

        public virtual CompetencyLevelSetup CompetencyLevel { get; set; }
        public virtual ICollection<MstDesigLinkCompetency> MstDesigLinkCompetencies { get; set; }
        public virtual ICollection<TrnsCdpdetail> TrnsCdpdetails { get; set; }
        public virtual ICollection<TrnsJrdetailCompetancy> TrnsJrdetailCompetancies { get; set; }
    }
}
