using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstPartnerPerformanceCategory
    {
        public MstPartnerPerformanceCategory()
        {
            MstPartnerPerformanceSubCats = new HashSet<MstPartnerPerformanceSubCat>();
            TrnsPartnerPerformanceFinalPostings = new HashSet<TrnsPartnerPerformanceFinalPosting>();
        }

        public int Id { get; set; }
        public int? YearId { get; set; }
        public string Code { get; set; }
        public string CategoryDescription { get; set; }
        public string CategoryType { get; set; }
        public decimal? Points { get; set; }
        public bool? FlgActive { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<MstPartnerPerformanceSubCat> MstPartnerPerformanceSubCats { get; set; }
        public virtual ICollection<TrnsPartnerPerformanceFinalPosting> TrnsPartnerPerformanceFinalPostings { get; set; }
    }
}
