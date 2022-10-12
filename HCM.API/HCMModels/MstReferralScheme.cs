using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstReferralScheme
    {
        public int InternalId { get; set; }
        public int? ElementId { get; set; }
        public int? Months { get; set; }
        public string Ptype { get; set; }
        public decimal? Pvalue { get; set; }
        public bool? FlgActive { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public virtual MstElement Element { get; set; }
    }
}
