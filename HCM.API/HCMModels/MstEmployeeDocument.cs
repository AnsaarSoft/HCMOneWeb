using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstEmployeeDocument
    {
        public int Id { get; set; }
        public int DocumentId { get; set; }
        public int EmpId { get; set; }
        public string DocumentExt { get; set; }
        public string DocumentPath { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public virtual MstDocumentCheckList Document { get; set; }
        public virtual MstEmployee Emp { get; set; }
    }
}
