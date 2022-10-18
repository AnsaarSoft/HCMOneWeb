using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsReHireEmployeeDetail
    {
        public int Id { get; set; }
        public int? ReHireId { get; set; }
        public string EmpName { get; set; }
        public DateTime? ServiceEndDate { get; set; }
        public DateTime? JoinningDate { get; set; }
        public DateTime? ConfirmationDate { get; set; }
        public DateTime? ContractEndDate { get; set; }
        public int? ConfirmStatus { get; set; }
        public string Category { get; set; }
        public string Scale { get; set; }
        public decimal? GrossSalary { get; set; }
        public decimal? BasicSalary { get; set; }
        public string ReportingManager { get; set; }
        public string Eobimember { get; set; }
        public string Eobinumber { get; set; }
        public string Ssm { get; set; }
        public string Ssn { get; set; }
        public string ProvidentFundBalance { get; set; }
        public string OtherIncome { get; set; }
        public string IncomeTaxRebate { get; set; }
        public int? TypeLov { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? TerminationDate { get; set; }
        public DateTime? ResignaitonDate { get; set; }
        public string ContractType { get; set; }
        public string PaymentMode { get; set; }
        public DateTime? NewConfirmationDate { get; set; }
        public DateTime? NewContractEndDate { get; set; }
        public DateTime? NewJoiningDate { get; set; }
        public string NewContractType { get; set; }
        public decimal? NewBasicSalary { get; set; }
        public int? ReportToId { get; set; }
        public bool? FlgActive { get; set; }
        public int? PositionId { get; set; }
        public string PositionName { get; set; }
        public int? NewPositionId { get; set; }
        public string NewPositionName { get; set; }
        public int? BranchId { get; set; }
        public string BranchName { get; set; }
        public int? NewBranchId { get; set; }
        public string NewBranchName { get; set; }
        public int? DesignationId { get; set; }
        public string DesignationName { get; set; }
        public int? NewDesignationId { get; set; }
        public string NewDesignationName { get; set; }
        public int? DeptId { get; set; }
        public string DeptName { get; set; }
        public int? NewDeptId { get; set; }
        public string NewDeptName { get; set; }
        public int? ManagerId { get; set; }
        public string ManagerName { get; set; }
        public int? NewManagerId { get; set; }
        public string NewManagerName { get; set; }
        public string LocationId { get; set; }
        public string LocationName { get; set; }
        public int? NewLocaitonId { get; set; }
        public string NewLocationName { get; set; }
        public int? PayrollId { get; set; }
        public string PayrollName { get; set; }
        public string NewPayRollName { get; set; }
        public string NewPayRollMode { get; set; }

        public virtual CfgPayrollDefination Payroll { get; set; }
        public virtual TrnsReHireEmployee ReHire { get; set; }
    }
}
