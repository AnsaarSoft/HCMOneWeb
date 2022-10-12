using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsWarningLetter
    {
        public int Id { get; set; }
        public int? EmpId { get; set; }
        public string WarningType { get; set; }
        public string Remarks { get; set; }
        public string Attachment { get; set; }
        public int? DocNum { get; set; }
        public byte? DocType { get; set; }
        public string DocStatus { get; set; }
        public string DocAprStatus { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public virtual MstEmployee Emp { get; set; }
    }
}
