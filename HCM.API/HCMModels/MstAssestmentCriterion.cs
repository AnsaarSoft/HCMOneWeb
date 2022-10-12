using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstAssestmentCriterion
    {
        public MstAssestmentCriterion()
        {
            TrnsInterviewEasassetments = new HashSet<TrnsInterviewEasassetment>();
            TrnsInterviewEaspanelists = new HashSet<TrnsInterviewEaspanelist>();
        }

        public int Id { get; set; }
        public int? AssestmentId { get; set; }
        public string Criteria { get; set; }
        public string Description { get; set; }
        public decimal? Marks { get; set; }
        public decimal? MinMarks { get; set; }
        public DateTime? CreateDt { get; set; }
        public string UserId { get; set; }
        public DateTime? UpdateDt { get; set; }
        public string UpdatedBy { get; set; }

        public virtual MstAssestment Assestment { get; set; }
        public virtual ICollection<TrnsInterviewEasassetment> TrnsInterviewEasassetments { get; set; }
        public virtual ICollection<TrnsInterviewEaspanelist> TrnsInterviewEaspanelists { get; set; }
    }
}
