using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class ApprovalDecisionRegisterDetail
    {
        public int Id { get; set; }
        public int? Adid { get; set; }
        public int? EmpId { get; set; }
        public string ApprovalStatus { get; set; }
        public DateTime? ActionTakenDate { get; set; }
        public string Comments { get; set; }
        public decimal? ChangedAmount { get; set; }
        public decimal? ApprovedInstallment { get; set; }
        public decimal? ApprovedSalary { get; set; }

        public virtual MstEmployee Emp { get; set; }
    }
}
