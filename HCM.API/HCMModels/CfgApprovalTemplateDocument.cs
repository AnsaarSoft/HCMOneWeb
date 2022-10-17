using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class CfgApprovalTemplateDocument
    {
        public int Id { get; set; }
        public int? Atid { get; set; }
        public bool? FlgJobRequisition { get; set; }
        public bool? FlgCandidate { get; set; }
        public bool? FlgEmpHiring { get; set; }
        public bool? FlgEmpLeave { get; set; }
        public bool? FlgResignation { get; set; }
        public bool? FlgLoan { get; set; }
        public bool? FlgAppraisal { get; set; }
        public bool? FlgAdvance { get; set; }
        public bool? FlgEmpTransfer { get; set; }

        public virtual CfgApprovalTemplate At { get; set; }
    }
}
