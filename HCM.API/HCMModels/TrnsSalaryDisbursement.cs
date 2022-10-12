using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsSalaryDisbursement
    {
        public int Id { get; set; }
        public string EmpId { get; set; }
        public string EmpName { get; set; }
        public int? DeptId { get; set; }
        public int? PayrollId { get; set; }
        public int? PayrollPeriodId { get; set; }
        public decimal? BasicSallary { get; set; }
        public decimal? GorssSallary { get; set; }
        public decimal? NetSallary { get; set; }
        public decimal? Amount { get; set; }
        public string ValueType { get; set; }
        public int? ValueId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
