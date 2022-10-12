using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstSecondment
    {
        public int Id { get; set; }
        public int? DocNum { get; set; }
        public string TypeDocument { get; set; }
        public string ReleaseAttachment { get; set; }
        public string ReturnAttachment { get; set; }
        public string Extension { get; set; }
        public int? EmpId { get; set; }
        public string EmpCode { get; set; }
        public string EmpName { get; set; }
        public int? DesignationId { get; set; }
        public string DesignationName { get; set; }
        public int? DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string CurrentPaymentMode { get; set; }
        public string ProjectId { get; set; }
        public string ProjectName { get; set; }
        public int? HostOfficeId { get; set; }
        public string HostOfficeName { get; set; }
        public string DimensionName { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public bool? StopSalary { get; set; }
        public string Remarks { get; set; }
        public int? UserCode { get; set; }
        public int? DocType { get; set; }
        public string DocStatus { get; set; }
        public string DocStatusLov { get; set; }
        public string DocAprStatus { get; set; }
        public string DocAprStatusLov { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public bool? FlgActive { get; set; }
        public int? ReleaseRef { get; set; }

        public virtual MstEmployee Emp { get; set; }
    }
}
