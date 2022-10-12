using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstEmpFingerRegister
    {
        public int Id { get; set; }
        public int? EmpId { get; set; }
        public string EmpCode { get; set; }
        public byte[] NewThumbPrint { get; set; }
        public byte[] OldThumbPrint { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
