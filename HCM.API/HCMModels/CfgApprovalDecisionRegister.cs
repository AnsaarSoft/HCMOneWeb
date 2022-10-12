using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class CfgApprovalDecisionRegister
    {
        public int Id { get; set; }
        public string EmpId { get; set; }
        public string EmployeeName { get; set; }
        public DateTime? TimeStamp { get; set; }
        public bool? FlgActive { get; set; }
        public byte? DocType { get; set; }
        public int? DocNum { get; set; }
        public int? Series { get; set; }
        public string LineStatusId { get; set; }
        public string LineStatusLovtype { get; set; }
        public string StageName { get; set; }
        public string ApprovalTempName { get; set; }
        public string Remarks { get; set; }
        public DateTime? CreateDt { get; set; }
        public DateTime? UpdateDt { get; set; }
        public int? StageId { get; set; }
        public int? PendingAtStageId { get; set; }
        public int? DocHierarchyId { get; set; }
        public int? EmployeeId { get; set; }
    }
}
