using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsPartnerNetProfit
    {
        public TrnsPartnerNetProfit()
        {
            TrnsPartnerNetProfitDetails = new HashSet<TrnsPartnerNetProfitDetail>();
        }

        public int Id { get; set; }
        public int? DocNum { get; set; }
        public int? FiscalYear { get; set; }
        public int? AllocatedPoints { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? SubCatId { get; set; }

        public virtual MstCalendar FiscalYearNavigation { get; set; }
        public virtual MstPartnerPerformanceSubCatDetail SubCat { get; set; }
        public virtual ICollection<TrnsPartnerNetProfitDetail> TrnsPartnerNetProfitDetails { get; set; }
    }
}
