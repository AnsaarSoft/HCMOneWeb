using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstCompetencyGroup
    {
        public MstCompetencyGroup()
        {
            TrnsCompetencyProfileDetails = new HashSet<TrnsCompetencyProfileDetail>();
            TrnsPerformanceAppraisal360s = new HashSet<TrnsPerformanceAppraisal360>();
        }

        public int Id { get; set; }
        public string GroupId { get; set; }
        public string CompGroup { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdateBy { get; set; }

        public virtual ICollection<TrnsCompetencyProfileDetail> TrnsCompetencyProfileDetails { get; set; }
        public virtual ICollection<TrnsPerformanceAppraisal360> TrnsPerformanceAppraisal360s { get; set; }
    }
}
