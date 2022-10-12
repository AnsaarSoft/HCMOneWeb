using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class DynamicApprovalHierarchy
    {
        public int Id { get; set; }
        public int? RegionalHeadId { get; set; }
        public string RegionalHeadName { get; set; }
        public int? EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int? BranchId { get; set; }
        public string BranchName { get; set; }
        public string Status { get; set; }
        public byte? DocType { get; set; }
        public int? DocId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? FlgActive { get; set; }
        public string MovingTo { get; set; }
    }
}
