using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstHierarchySetup
    {
        public int Id { get; set; }
        public int? DocType { get; set; }
        public bool? FlgAddNoHierarchy { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
