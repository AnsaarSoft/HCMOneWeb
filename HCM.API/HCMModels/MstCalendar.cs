using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstCalendar
    {
        public MstCalendar()
        {
            CfgTaxSetups = new HashSet<CfgTaxSetup>();
            MstGoalsRulesses = new HashSet<MstGoalsRuless>();
            MstMpps = new HashSet<MstMpp>();
            MstObjectives = new HashSet<MstObjective>();
            MstPartnerFeedbackAssigns = new HashSet<MstPartnerFeedbackAssign>();
            MstPartnerPerformanceSubCats = new HashSet<MstPartnerPerformanceSubCat>();
            MstPartnerPerformanceTerms = new HashSet<MstPartnerPerformanceTerm>();
            MstPerformanceTerms = new HashSet<MstPerformanceTerm>();
            MstProbationCategories = new HashSet<MstProbationCategory>();
            MstProbationEvalCriteria = new HashSet<MstProbationEvalCriterion>();
            MstProbationEvalCycles = new HashSet<MstProbationEvalCycle>();
            PerformanceStatementTermAttachments = new HashSet<PerformanceStatementTermAttachment>();
            TrnsObjFnyHeads = new HashSet<TrnsObjFnyHead>();
            TrnsPartnerAssessmentHeads = new HashSet<TrnsPartnerAssessmentHead>();
            TrnsPartnerBusinessRevenues = new HashSet<TrnsPartnerBusinessRevenue>();
            TrnsPartnerContributionPools = new HashSet<TrnsPartnerContributionPool>();
            TrnsPartnerFacilitateTrainingHeads = new HashSet<TrnsPartnerFacilitateTrainingHead>();
            TrnsPartnerNetProfits = new HashSet<TrnsPartnerNetProfit>();
            TrnsPartnerRevenueAccruals = new HashSet<TrnsPartnerRevenueAccrual>();
            TrnsPartnerUnAllocatedFormsHeads = new HashSet<TrnsPartnerUnAllocatedFormsHead>();
            TrnsTaxAdjustments = new HashSet<TrnsTaxAdjustment>();
        }

        public string Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? FlgActive { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }

        public virtual ICollection<CfgTaxSetup> CfgTaxSetups { get; set; }
        public virtual ICollection<MstGoalsRuless> MstGoalsRulesses { get; set; }
        public virtual ICollection<MstMpp> MstMpps { get; set; }
        public virtual ICollection<MstObjective> MstObjectives { get; set; }
        public virtual ICollection<MstPartnerFeedbackAssign> MstPartnerFeedbackAssigns { get; set; }
        public virtual ICollection<MstPartnerPerformanceSubCat> MstPartnerPerformanceSubCats { get; set; }
        public virtual ICollection<MstPartnerPerformanceTerm> MstPartnerPerformanceTerms { get; set; }
        public virtual ICollection<MstPerformanceTerm> MstPerformanceTerms { get; set; }
        public virtual ICollection<MstProbationCategory> MstProbationCategories { get; set; }
        public virtual ICollection<MstProbationEvalCriterion> MstProbationEvalCriteria { get; set; }
        public virtual ICollection<MstProbationEvalCycle> MstProbationEvalCycles { get; set; }
        public virtual ICollection<PerformanceStatementTermAttachment> PerformanceStatementTermAttachments { get; set; }
        public virtual ICollection<TrnsObjFnyHead> TrnsObjFnyHeads { get; set; }
        public virtual ICollection<TrnsPartnerAssessmentHead> TrnsPartnerAssessmentHeads { get; set; }
        public virtual ICollection<TrnsPartnerBusinessRevenue> TrnsPartnerBusinessRevenues { get; set; }
        public virtual ICollection<TrnsPartnerContributionPool> TrnsPartnerContributionPools { get; set; }
        public virtual ICollection<TrnsPartnerFacilitateTrainingHead> TrnsPartnerFacilitateTrainingHeads { get; set; }
        public virtual ICollection<TrnsPartnerNetProfit> TrnsPartnerNetProfits { get; set; }
        public virtual ICollection<TrnsPartnerRevenueAccrual> TrnsPartnerRevenueAccruals { get; set; }
        public virtual ICollection<TrnsPartnerUnAllocatedFormsHead> TrnsPartnerUnAllocatedFormsHeads { get; set; }
        public virtual ICollection<TrnsTaxAdjustment> TrnsTaxAdjustments { get; set; }
    }
}
