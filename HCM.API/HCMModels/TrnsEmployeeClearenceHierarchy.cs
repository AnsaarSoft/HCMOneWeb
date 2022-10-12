using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsEmployeeClearenceHierarchy
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int? DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int? ApproverId { get; set; }
        public string ApproverName { get; set; }
        public bool? FlgActive { get; set; }
    }
}
