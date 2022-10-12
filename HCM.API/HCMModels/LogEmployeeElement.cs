using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class LogEmployeeElement
    {
        public int InternalId { get; set; }
        public string EmpId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public bool? FlgActive { get; set; }
    }
}
