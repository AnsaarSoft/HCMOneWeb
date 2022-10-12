using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstPartnerFeedbackStmntDetail
    {
        public MstPartnerFeedbackStmntDetail()
        {
            TrnsPartnerAssessmentDetails = new HashSet<TrnsPartnerAssessmentDetail>();
            TrnsPartnerFeedback360s = new HashSet<TrnsPartnerFeedback360>();
        }

        public int Id { get; set; }
        public int? FeedbackStmntId { get; set; }
        public int? CompetencyId { get; set; }
        public string CompetencyStmnt { get; set; }
        public bool? FlgActive { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual MstPartnerFeedbackDetail Competency { get; set; }
        public virtual MstPartnerFeedbackStmnt FeedbackStmnt { get; set; }
        public virtual ICollection<TrnsPartnerAssessmentDetail> TrnsPartnerAssessmentDetails { get; set; }
        public virtual ICollection<TrnsPartnerFeedback360> TrnsPartnerFeedback360s { get; set; }
    }
}
