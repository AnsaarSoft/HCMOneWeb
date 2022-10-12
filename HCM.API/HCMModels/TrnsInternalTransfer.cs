using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsInternalTransfer
    {
        public int Id { get; set; }
        public byte? DocType { get; set; }
        public int? DocNum { get; set; }
        public DateTime? DocDate { get; set; }
        public int? NewLocationId { get; set; }
        public int? NewDepartmentId { get; set; }
        public int EmpId { get; set; }
        public int? ManagerId { get; set; }
        public string DocStatusLov { get; set; }
        public string DocAprStatus { get; set; }
        public string DocAprStatusLov { get; set; }
        public string DocStatus { get; set; }
        public DateTime? TransferDate { get; set; }
        public string Remarks { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public int? OldDepartmentId { get; set; }
        public int? OldLocationId { get; set; }
        public int? OldManager { get; set; }
        public int? NewManager { get; set; }
        public int? OldReportTo { get; set; }
        public int? NewReportTo { get; set; }
        public int? NewBranchId { get; set; }

        public virtual MstEmployee Emp { get; set; }
        public virtual MstEmployee Manager { get; set; }
        public virtual MstBranch NewBranch { get; set; }
        public virtual MstDepartment NewDepartment { get; set; }
        public virtual MstLocation NewLocation { get; set; }
    }
}
