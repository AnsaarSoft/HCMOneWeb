using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsDutyResumption
    {
        public int Id { get; set; }
        public int? EmpId { get; set; }
        public int? LeaveType { get; set; }
        public DateTime? ResumptionDate { get; set; }
        public DateTime? LeaveEndDate { get; set; }
        public string Remarks { get; set; }
        public string FilePath { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
