using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsPartnerFeedback360
    {
        public int Id { get; set; }
        public int? PartnerId { get; set; }
        public bool? FlgPartner { get; set; }
        public int? ComptncyStmntId { get; set; }
        public int? Respondent { get; set; }
        public int? Score { get; set; }
        public decimal? Weightage { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual MstPartnerFeedbackStmntDetail ComptncyStmnt { get; set; }
        public virtual MstEmployee Partner { get; set; }
    }
}
