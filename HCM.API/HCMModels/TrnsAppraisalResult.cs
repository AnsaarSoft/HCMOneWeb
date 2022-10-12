using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsAppraisalResult
    {
        public int Id { get; set; }
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpCode { get; set; }
        public decimal Score { get; set; }
        public decimal IncrementPercent { get; set; }
        public decimal CurrentSalary { get; set; }
        public decimal ProposedSalary { get; set; }
        public decimal Salaryfinalized { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public int? PerformanceId { get; set; }
    }
}
