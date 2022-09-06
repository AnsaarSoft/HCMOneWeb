using System;
using System.Collections.Generic;

namespace HCM.API.Models
{
    public partial class MstEmployeeAttachment
    {
        public int Id { get; set; }
        public int EmpId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual MstEmployee Emp { get; set; }
    }
}
