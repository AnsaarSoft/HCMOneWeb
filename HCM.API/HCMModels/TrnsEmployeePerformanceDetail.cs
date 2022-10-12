using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsEmployeePerformanceDetail
    {
        public int Id { get; set; }
        public int? AllowanceId { get; set; }
        public int? EmployeeId { get; set; }
        public string EmpName { get; set; }
        public int? EelementId { get; set; }
        public decimal? Percentage { get; set; }
        public decimal? Amount { get; set; }
        public bool? FlgActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public virtual TrnsEmployeePerformance Allowance { get; set; }
    }
}
