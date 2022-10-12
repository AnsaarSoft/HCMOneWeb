using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsAdvancePaymentBatchDetail
    {
        public int Id { get; set; }
        public int? Fkid { get; set; }
        public int? EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int? BranchId { get; set; }
        public decimal? BasicSalary { get; set; }
        public decimal? BasicSalaryEarned { get; set; }
        public decimal? Allowance { get; set; }
        public decimal? AbsentDeduction { get; set; }
        public int? EarlyLateInMinutes { get; set; }
        public int? OverTimeInMinutes { get; set; }
        public decimal? Otdeduction { get; set; }
        public decimal? AdvanceDeduction { get; set; }
        public decimal? LoanInstallment { get; set; }
        public decimal? NetAmount { get; set; }
        public decimal? AdvancePercentage { get; set; }
        public decimal? MaxAdvanceAllowed { get; set; }
        public decimal? AdvanceApproved { get; set; }
        public bool? FlgActive { get; set; }
        public int? TargetAdvanceRefDoc { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public int? DepartmentId { get; set; }

        public virtual TrnsAdvancePaymentBatch Fk { get; set; }
    }
}
