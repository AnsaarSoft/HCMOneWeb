using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsGenericRequest
    {
        public int Id { get; set; }
        public int? EmpId { get; set; }
        public string EmpName { get; set; }
        public DateTime? JoiningDate { get; set; }
        public DateTime? DateOfRequest { get; set; }
        public string Branch { get; set; }
        public string RequestType { get; set; }
        public int? GenericId { get; set; }
        public string DocStatus { get; set; }
        public string DocAprovalStatus { get; set; }
        public int? DocNum { get; set; }
        public int? DocType { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdatedBy { get; set; }

        public virtual MstEmployee Emp { get; set; }
        public virtual MstGenericRequest Generic { get; set; }
    }
}
