using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsPartnerFacilitateTrainingHead
    {
        public TrnsPartnerFacilitateTrainingHead()
        {
            TrnsPartnerFacilitateTrainingDetails = new HashSet<TrnsPartnerFacilitateTrainingDetail>();
        }

        public int Id { get; set; }
        public int? DocNum { get; set; }
        public int? FiscalYear { get; set; }
        public decimal? AllocatedPoints { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int? SubCatDetailId { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual MstCalendar FiscalYearNavigation { get; set; }
        public virtual MstPartnerPerformanceSubCatDetail SubCatDetail { get; set; }
        public virtual ICollection<TrnsPartnerFacilitateTrainingDetail> TrnsPartnerFacilitateTrainingDetails { get; set; }
    }
}
