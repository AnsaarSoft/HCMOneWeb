using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsElementPerRate
    {
        public TrnsElementPerRate()
        {
            TrnsElementPerRateDetails = new HashSet<TrnsElementPerRateDetail>();
        }

        public int Id { get; set; }
        public int? DocNum { get; set; }
        public string DocStatus { get; set; }
        public int? PayrollLink { get; set; }
        public int? PeriodLink { get; set; }
        public string ProcessOn { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual ICollection<TrnsElementPerRateDetail> TrnsElementPerRateDetails { get; set; }
    }
}
