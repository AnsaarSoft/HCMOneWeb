using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsInterviewEasassetment
    {
        public int Id { get; set; }
        public int? Ieasid { get; set; }
        public int? CriteriaId { get; set; }
        public int? PanelistId { get; set; }
        public string Description { get; set; }
        public decimal? Marks { get; set; }
        public decimal? Required { get; set; }
        public decimal? Obtain { get; set; }
        public string Remarks { get; set; }
        public DateTime? CreateDt { get; set; }
        public string UserId { get; set; }
        public DateTime? UpdateDt { get; set; }
        public string UpdatedBy { get; set; }

        public virtual MstAssestmentCriterion Criteria { get; set; }
        public virtual TrnsInterviewEa Ieas { get; set; }
        public virtual MstEmployee Panelist { get; set; }
    }
}
