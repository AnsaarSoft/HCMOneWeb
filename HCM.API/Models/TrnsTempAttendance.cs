using System;
using System.Collections.Generic;

namespace HCM.API.Models
{
    public partial class TrnsTempAttendance
    {
        public int Id { get; set; }
        public string EmpId { get; set; }
        public DateTime? PunchedDate { get; set; }
        public string PunchedTime { get; set; }
        public string InOut { get; set; }
        public bool? FlgProcessed { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
