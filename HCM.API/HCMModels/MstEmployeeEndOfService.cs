using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstEmployeeEndOfService
    {
        public int Id { get; set; }
        public int EmpId { get; set; }
        public byte? ServiceEndTypeId { get; set; }
        public string ServiceEndTypeDesc { get; set; }
        public DateTime? ServiceEndDate { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual MstEmployee Emp { get; set; }
    }
}
