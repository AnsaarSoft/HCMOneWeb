using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsLstslab
    {
        public TrnsLstslab()
        {
            TrnsLstslabDetails = new HashSet<TrnsLstslabDetail>();
            TrnsLstslabPeriods = new HashSet<TrnsLstslabPeriod>();
        }

        public int InternalId { get; set; }
        public int? FkfiscalYear { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual ICollection<TrnsLstslabDetail> TrnsLstslabDetails { get; set; }
        public virtual ICollection<TrnsLstslabPeriod> TrnsLstslabPeriods { get; set; }
    }
}
