using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class NeskCfgDocHierarchyDetail
    {
        public int Id { get; set; }
        public int? DocHirerchyId { get; set; }
        public int? HirerchyLevel { get; set; }
        public string HirerchyLevelDesc { get; set; }
        public int? EmpId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public bool? FlgActive { get; set; }

        public virtual NeskCfgDocHierarchy DocHirerchy { get; set; }
        public virtual MstEmployee Emp { get; set; }
    }
}
