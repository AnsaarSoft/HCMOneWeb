using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class ApprovalDecisionRegister
    {
        public int Id { get; set; }
        public int? DocNum { get; set; }
        public int? DocType { get; set; }
        public int? DocHierarchyId { get; set; }
        public string LineStatusId { get; set; }
        public string LineStatusLovtype { get; set; }
        public int? PendingAtStageId { get; set; }
        public string StageDescription { get; set; }
        public string Remarks { get; set; }
        public DateTime? TimeStamp { get; set; }
        public bool? FlgActive { get; set; }
        public int? StageId { get; set; }
        public int? EmpId { get; set; }

        public virtual DocumentTemplate DocHierarchy { get; set; }
        public virtual MstEmployee Emp { get; set; }
    }
}
