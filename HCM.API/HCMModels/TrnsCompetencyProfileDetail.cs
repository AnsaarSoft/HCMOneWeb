using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsCompetencyProfileDetail
    {
        public TrnsCompetencyProfileDetail()
        {
            TrnsPerformanceAppraisal360Details = new HashSet<TrnsPerformanceAppraisal360Detail>();
        }

        public int Id { get; set; }
        public int? Cpid { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int? Cgid { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }

        public virtual MstCompetencyGroup Cg { get; set; }
        public virtual TrnsCompetencyProfile Cp { get; set; }
        public virtual ICollection<TrnsPerformanceAppraisal360Detail> TrnsPerformanceAppraisal360Details { get; set; }
    }
}
