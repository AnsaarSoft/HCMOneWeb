using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsResignation
    {
        public int Id { get; set; }
        public short? DocType { get; set; }
        public string DocName { get; set; }
        public string Extension { get; set; }
        public int? Series { get; set; }
        public int? DocNum { get; set; }
        public int? EmpId { get; set; }
        public DateTime? DateOfJoining { get; set; }
        public DateTime? ResignDate { get; set; }
        public DateTime? TerminationDate { get; set; }
        public string ResignationReason { get; set; }
        public int? NoticeDays { get; set; }
        public bool? FlgOption1 { get; set; }
        public bool? FlgOption2 { get; set; }
        public bool? FlgOption3 { get; set; }
        public bool? FlgOption4 { get; set; }
        public bool? FlgOption5 { get; set; }
        public bool? FlgOption6 { get; set; }
        public bool? FlgOption7 { get; set; }
        public string DocStatus { get; set; }
        public string DocStatusLov { get; set; }
        public string DocAprStatus { get; set; }
        public string DocAprStatusLov { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }
        public int? ManagerId { get; set; }
        public int? OriginatorId { get; set; }
        public int? DepartmentId { get; set; }
        public int? DesignationId { get; set; }
        public int? EmpTermCount { get; set; }
        public string TypeOfResignation { get; set; }
        public bool? IsHr { get; set; }
        public bool? StopSalary { get; set; }
        public string CurrentPaymentMode { get; set; }

        public virtual MstDepartment Department { get; set; }
        public virtual MstEmployee Emp { get; set; }
    }
}
