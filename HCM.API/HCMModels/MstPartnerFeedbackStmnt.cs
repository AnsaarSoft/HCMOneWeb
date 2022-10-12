using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstPartnerFeedbackStmnt
    {
        public MstPartnerFeedbackStmnt()
        {
            MstPartnerFeedbackStmntDetails = new HashSet<MstPartnerFeedbackStmntDetail>();
        }

        public int Id { get; set; }
        public int? FeebackId { get; set; }
        public bool? FlgActive { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual MstPartnerFeedback Feeback { get; set; }
        public virtual ICollection<MstPartnerFeedbackStmntDetail> MstPartnerFeedbackStmntDetails { get; set; }
    }
}
