using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsPartnerAssessmentHead
    {
        public TrnsPartnerAssessmentHead()
        {
            TrnsPartnerAssessmentDetails = new HashSet<TrnsPartnerAssessmentDetail>();
        }

        public int Id { get; set; }
        public int? EmpId { get; set; }
        public decimal? TotalScore { get; set; }
        public int? AssessmentLevel { get; set; }
        public bool? FlgActive { get; set; }
        public string DocStatus { get; set; }
        public string DocAprStatus { get; set; }
        public string FiscalYear { get; set; }
        public int? FeedbackId { get; set; }
        public string PartnerFunction { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Remarks { get; set; }

        public virtual MstEmployee Emp { get; set; }
        public virtual MstPartnerFeedback Feedback { get; set; }
        public virtual MstCalendar FiscalYearNavigation { get; set; }
        public virtual ICollection<TrnsPartnerAssessmentDetail> TrnsPartnerAssessmentDetails { get; set; }
    }
}
