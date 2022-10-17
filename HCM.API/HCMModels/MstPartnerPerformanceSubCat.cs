using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstPartnerPerformanceSubCat
    {
        public MstPartnerPerformanceSubCat()
        {
            MstPartnerPerformanceSubCatDetails = new HashSet<MstPartnerPerformanceSubCatDetail>();
        }

        public int Id { get; set; }
        public string YearId { get; set; }
        public int? CatId { get; set; }
        public string Description { get; set; }
        public decimal? TotalPoints { get; set; }
        public bool? FlgActive { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual MstPartnerPerformanceCategory Cat { get; set; }
        public virtual MstCalendar Year { get; set; }
        public virtual ICollection<MstPartnerPerformanceSubCatDetail> MstPartnerPerformanceSubCatDetails { get; set; }
    }
}
