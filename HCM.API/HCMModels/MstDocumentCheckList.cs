using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstDocumentCheckList
    {
        public MstDocumentCheckList()
        {
            MstEmployeeDocuments = new HashSet<MstEmployeeDocument>();
        }

        public int Id { get; set; }
        public string DocumentName { get; set; }
        public bool? Mandatory { get; set; }
        public bool? FlgActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public virtual ICollection<MstEmployeeDocument> MstEmployeeDocuments { get; set; }
    }
}
