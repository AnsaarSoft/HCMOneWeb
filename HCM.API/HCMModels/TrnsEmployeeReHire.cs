using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsEmployeeReHire
    {
        public int InternalId { get; set; }
        public int? DocNo { get; set; }
        public DateTime? DocDate { get; set; }
        public int? EmpId { get; set; }
        public string EmployeeName { get; set; }
        public int? DepartmentOld { get; set; }
        public string DepartNameOld { get; set; }
        public int? DesignationOld { get; set; }
        public string DesigNameOld { get; set; }
        public int? LocationOld { get; set; }
        public string LocNameOld { get; set; }
        public int? BranchOld { get; set; }
        public string BranchNameOld { get; set; }
        public int? ManagerIdold { get; set; }
        public string ManagerNameOld { get; set; }
        public decimal? Bsold { get; set; }
        public decimal? Gsold { get; set; }
        public DateTime? JoiningDtOld { get; set; }
        public DateTime? ResignationDtOld { get; set; }
        public DateTime? TerminationDtOld { get; set; }
        public int? LocationIdnew { get; set; }
        public string LocationNameNew { get; set; }
        public int? DepartmentIdnew { get; set; }
        public string DepartmentNameNew { get; set; }
        public int? DesignationIdnew { get; set; }
        public string DesignationNameNew { get; set; }
        public int? BranchIdnew { get; set; }
        public string BranchNameNew { get; set; }
        public int? ManagerIdnew { get; set; }
        public string ManagerNameNew { get; set; }
        public decimal? Bsnew { get; set; }
        public DateTime? JoiningDtNew { get; set; }
        public int? TermCount { get; set; }
        public bool? FlgReHire { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreateDt { get; set; }
        public DateTime? UpdateDt { get; set; }
        public string ContractTypeOld { get; set; }
        public string ContractTypeNew { get; set; }
        public int? PositionIdOld { get; set; }
        public int? PositionIdNew { get; set; }
        public int? ReportToOld { get; set; }
        public int? ReportToNew { get; set; }
        public string PayrollModeOld { get; set; }
        public string PayrollModeNew { get; set; }
        public string PayrollNameOld { get; set; }
        public string PayrollNameNew { get; set; }
        public string PaymentModeOld { get; set; }
        public string PaymentModeNew { get; set; }
        public int? PayrollIdOld { get; set; }
        public int? PayrollIdNew { get; set; }
        public decimal? Gsnew { get; set; }
        public string EmployeeContractType { get; set; }

        public virtual MstEmployee Emp { get; set; }
    }
}
