using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class ViewApprovalTemplate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? StageId { get; set; }
        public byte? Priorty { get; set; }
        public bool? FlgJobRequisition { get; set; }
        public bool? FlgEmpHiring { get; set; }
        public bool? FlgCandidate { get; set; }
        public bool? FlgEmpLeave { get; set; }
        public bool? FlgResignation { get; set; }
        public bool? FlgLoan { get; set; }
        public bool? FlgAppraisal { get; set; }
        public bool? FlgAdvance { get; set; }
        public string StageName { get; set; }
    }
}
