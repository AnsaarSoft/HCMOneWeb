using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsPartnerAssessmentDetail
    {
        public int Id { get; set; }
        public int? HeadId { get; set; }
        public int? StmntId { get; set; }
        public bool HighPerformance { get; set; }
        public bool TargetPerformance { get; set; }
        public bool BelowPerformance { get; set; }
        public decimal? Score { get; set; }
        public decimal? Percentage { get; set; }
        public int? EmpId { get; set; }
        public bool? FlgPartner { get; set; }

        public virtual MstEmployee Emp { get; set; }
        public virtual TrnsPartnerAssessmentHead Head { get; set; }
        public virtual MstPartnerFeedbackStmntDetail Stmnt { get; set; }
    }
}
