using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsTempAttendance
    {
        public int Id { get; set; }
        public int FkempId { get; set; }
        public string EmpId { get; set; }
        public DateTime? PunchedDate { get; set; }
        public string PunchedTime { get; set; }
        public string InOut { get; set; }
        public bool? FlgProcessed { get; set; }
        public DateTime? PunchedDateTime { get; set; }
        public DateTime? PolledDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UserId { get; set; }
        public string CostCenter { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
