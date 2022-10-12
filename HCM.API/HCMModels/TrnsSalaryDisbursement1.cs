using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsSalaryDisbursement1
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public int? PayrollId { get; set; }
        public int? PeriodId { get; set; }
        public decimal? BasicSalary { get; set; }
        public decimal? GrossSalary { get; set; }
        public decimal? NetSalary { get; set; }
        public decimal? DisburseAmount { get; set; }
        public int? DocumentNumber { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
