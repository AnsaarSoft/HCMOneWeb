using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstPartnerFeedbackDetail
    {
        public MstPartnerFeedbackDetail()
        {
            MstPartnerFeedbackStmntDetails = new HashSet<MstPartnerFeedbackStmntDetail>();
            TrnsPeerFeedback360s = new HashSet<TrnsPeerFeedback360>();
        }

        public int Id { get; set; }
        public int? HfeedbackId { get; set; }
        public string CompetencyName { get; set; }
        public bool? FlgActive { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual MstPartnerFeedback Hfeedback { get; set; }
        public virtual ICollection<MstPartnerFeedbackStmntDetail> MstPartnerFeedbackStmntDetails { get; set; }
        public virtual ICollection<TrnsPeerFeedback360> TrnsPeerFeedback360s { get; set; }
    }
}
