using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsEmployeeLoan
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public string EmpDepartment { get; set; }
        public string EmpDesignation { get; set; }
        public string EmpCostCenter { get; set; }
        public decimal? GrossSalary { get; set; }
        public int PayrollId { get; set; }
        public string PayrollName { get; set; }
        public decimal? LoanAmount { get; set; }
        public DateTime? LoanDate { get; set; }
        public string Remark { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }
    }
}
