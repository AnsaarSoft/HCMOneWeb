using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class NeskCfgApprovalDecisionRegister
    {
        public long Id { get; set; }
        public int? DocNum { get; set; }
        public int? DocType { get; set; }
        public int? EmpId { get; set; }
        public int? ApproverId { get; set; }
        public string ApproverEmailId { get; set; }
        public string ApproverName { get; set; }
        public int? DocHirerchyId { get; set; }
        public string LineStatusId { get; set; }
        public string LineStatusLovtype { get; set; }
        public int? PendingAtLevelId { get; set; }
        public int? LevelId { get; set; }
        public string LevelDesc { get; set; }
        public string Remarks { get; set; }
        public DateTime? TimeStamp { get; set; }
        public bool? FlgActive { get; set; }

        public virtual MstEmployee Approver { get; set; }
        public virtual NeskCfgDocHierarchy DocHirerchy { get; set; }
        public virtual MstEmployee Emp { get; set; }
    }
}
