using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsOtslabDetail
    {
        public int InternalId { get; set; }
        public int? ParentId { get; set; }
        public int? Ottype { get; set; }
        public decimal? LowerLimit { get; set; }
        public decimal? UpperLimit { get; set; }
        public int? Priority { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual MstOverTime OttypeNavigation { get; set; }
        public virtual TrnsOtslab Parent { get; set; }
    }
}
