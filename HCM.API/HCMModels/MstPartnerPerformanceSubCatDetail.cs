using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstPartnerPerformanceSubCatDetail
    {
        public MstPartnerPerformanceSubCatDetail()
        {
            TrnsPartnerBusinessRevenues = new HashSet<TrnsPartnerBusinessRevenue>();
            TrnsPartnerContributionPools = new HashSet<TrnsPartnerContributionPool>();
            TrnsPartnerFacilitateTrainingHeads = new HashSet<TrnsPartnerFacilitateTrainingHead>();
            TrnsPartnerNetProfits = new HashSet<TrnsPartnerNetProfit>();
            TrnsPartnerRevenueAccruals = new HashSet<TrnsPartnerRevenueAccrual>();
            TrnsPartnerUnAllocatedFormsHeads = new HashSet<TrnsPartnerUnAllocatedFormsHead>();
        }

        public int Id { get; set; }
        public int? HeadId { get; set; }
        public string SubCatCode { get; set; }
        public string EvaluationLink { get; set; }
        public string BasisOfEvaluation { get; set; }
        public decimal? Points { get; set; }
        public string SubCatDescription { get; set; }
        public string AssessmentFramework { get; set; }

        public virtual MstPartnerPerformanceSubCat Head { get; set; }
        public virtual ICollection<TrnsPartnerBusinessRevenue> TrnsPartnerBusinessRevenues { get; set; }
        public virtual ICollection<TrnsPartnerContributionPool> TrnsPartnerContributionPools { get; set; }
        public virtual ICollection<TrnsPartnerFacilitateTrainingHead> TrnsPartnerFacilitateTrainingHeads { get; set; }
        public virtual ICollection<TrnsPartnerNetProfit> TrnsPartnerNetProfits { get; set; }
        public virtual ICollection<TrnsPartnerRevenueAccrual> TrnsPartnerRevenueAccruals { get; set; }
        public virtual ICollection<TrnsPartnerUnAllocatedFormsHead> TrnsPartnerUnAllocatedFormsHeads { get; set; }
    }
}
