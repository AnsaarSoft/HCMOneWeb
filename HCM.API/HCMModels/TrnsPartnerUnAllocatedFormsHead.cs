using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsPartnerUnAllocatedFormsHead
    {
        public TrnsPartnerUnAllocatedFormsHead()
        {
            TrnsPartnerUnAllocatedFormsDetails = new HashSet<TrnsPartnerUnAllocatedFormsDetail>();
        }

        public int Id { get; set; }
        public int? DocNum { get; set; }
        public int? FiscalYear { get; set; }
        public int? AllocatedPoints { get; set; }
        public int? SubCatDetailId { get; set; }
        public int? PartnerId { get; set; }
        public decimal? PartnerPercent { get; set; }
        public decimal? Total { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual MstCalendar FiscalYearNavigation { get; set; }
        public virtual MstEmployee Partner { get; set; }
        public virtual MstPartnerPerformanceSubCatDetail SubCatDetail { get; set; }
        public virtual ICollection<TrnsPartnerUnAllocatedFormsDetail> TrnsPartnerUnAllocatedFormsDetails { get; set; }
    }
}
