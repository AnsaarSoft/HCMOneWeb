using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsTrainingFeedbackDetail
    {
        public int Id { get; set; }
        public int? Fbid { get; set; }
        public int? StatementId { get; set; }
        public string Remarks { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public virtual TrnsTrainingFeedback Fb { get; set; }
        public virtual MstTrainingFeedback Statement { get; set; }
    }
}
