using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsInterviewEaspanelist
    {
        public int Id { get; set; }
        public int? Ieasid { get; set; }
        public int? PanelistId { get; set; }
        public int? CriteriaId { get; set; }
        public decimal? Marks { get; set; }
        public decimal? Obtained { get; set; }
        public decimal? Required { get; set; }
        public string Remarks { get; set; }

        public virtual MstAssestmentCriterion Criteria { get; set; }
        public virtual TrnsInterviewEa Ieas { get; set; }
        public virtual MstEmployee Panelist { get; set; }
    }
}
