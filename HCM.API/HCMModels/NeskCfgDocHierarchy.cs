using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class NeskCfgDocHierarchy
    {
        public NeskCfgDocHierarchy()
        {
            NeskCfgApprovalDecisionRegisters = new HashSet<NeskCfgApprovalDecisionRegister>();
            NeskCfgDocHierarchyDetails = new HashSet<NeskCfgDocHierarchyDetail>();
        }

        public int Id { get; set; }
        public int? DocType { get; set; }
        public string DocDesc { get; set; }
        public int? DepartId { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool? FlgFollowHierarchy { get; set; }

        public virtual MstDepartment Depart { get; set; }
        public virtual ICollection<NeskCfgApprovalDecisionRegister> NeskCfgApprovalDecisionRegisters { get; set; }
        public virtual ICollection<NeskCfgDocHierarchyDetail> NeskCfgDocHierarchyDetails { get; set; }
    }
}
