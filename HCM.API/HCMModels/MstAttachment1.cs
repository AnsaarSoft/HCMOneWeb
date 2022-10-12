using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstAttachment1
    {
        public int Id { get; set; }
        public int? EmpId { get; set; }
        public string Path1Link { get; set; }
        public byte[] Path1Image { get; set; }
        public string Path2Link { get; set; }
        public byte[] Path2Image { get; set; }
        public string Path3Link { get; set; }
        public byte[] Path3Image { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
