using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstPartnerFeedback
    {
        public MstPartnerFeedback()
        {
            MstPartnerFeedbackAssigns = new HashSet<MstPartnerFeedbackAssign>();
            MstPartnerFeedbackDetails = new HashSet<MstPartnerFeedbackDetail>();
            MstPartnerFeedbackStmnts = new HashSet<MstPartnerFeedbackStmnt>();
            TrnsPartnerAssessmentHeads = new HashSet<TrnsPartnerAssessmentHead>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool? FlgActive { get; set; }
        public decimal? Weightage { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<MstPartnerFeedbackAssign> MstPartnerFeedbackAssigns { get; set; }
        public virtual ICollection<MstPartnerFeedbackDetail> MstPartnerFeedbackDetails { get; set; }
        public virtual ICollection<MstPartnerFeedbackStmnt> MstPartnerFeedbackStmnts { get; set; }
        public virtual ICollection<TrnsPartnerAssessmentHead> TrnsPartnerAssessmentHeads { get; set; }
    }
}
