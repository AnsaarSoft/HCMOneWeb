using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsPayeslab
    {
        public TrnsPayeslab()
        {
            TrnsPayeslabDetails = new HashSet<TrnsPayeslabDetail>();
        }

        public int InternalId { get; set; }
        public int? FiscalYear { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual ICollection<TrnsPayeslabDetail> TrnsPayeslabDetails { get; set; }
    }
}
