using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class LgTrnsAdvance
    {
        public int Id { get; set; }
        public int? LoanId { get; set; }
        public int? DocNum { get; set; }
        public byte? DocType { get; set; }
        public int? Series { get; set; }
        public int? EmpId { get; set; }
        public string EmpName { get; set; }
        public int? ManagerId { get; set; }
        public string ManagerName { get; set; }
        public DateTime? DateOfJoining { get; set; }
        public int? DesignationId { get; set; }
        public string Designation { get; set; }
        public decimal? Salary { get; set; }
        public int? AdvanceType { get; set; }
        public decimal? RequestedAmount { get; set; }
        public DateTime? RequiredDate { get; set; }
        public decimal? ApprovedAmount { get; set; }
        public DateTime? MaturityDate { get; set; }
        public decimal? RemainingAmount { get; set; }
        public int? OriginatorId { get; set; }
        public string OriginatorName { get; set; }
        public string DocStatus { get; set; }
        public string DocStatusLov { get; set; }
        public string DocAprStatus { get; set; }
        public string DocAprStatusLov { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdateBy { get; set; }
        public bool? FlgActive { get; set; }
        public bool? FlgStop { get; set; }
        public bool? FlgPaid { get; set; }
        public int? TransId { get; set; }
        public int? DepartmentId { get; set; }
        public DateTime? InsertDate { get; set; }
    }
}
