using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsPeerFeedback360
    {
        public int Id { get; set; }
        public int? PeerId { get; set; }
        public int? ComptncyId { get; set; }
        public int? Respondent { get; set; }
        public int? Score { get; set; }
        public decimal? Weightage { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual MstPartnerFeedbackDetail Comptncy { get; set; }
        public virtual MstEmployee Peer { get; set; }
    }
}
