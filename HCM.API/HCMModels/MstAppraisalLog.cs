using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstAppraisalLog
    {
        public int Id { get; set; }
        public int FiscalYear { get; set; }
        public int DepartmentId { get; set; }
        public string DeparmentName { get; set; }
        public bool FlgAppraisalDone { get; set; }
        public DateTime Createddate { get; set; }
        public string CreatedBy { get; set; }
    }
}
