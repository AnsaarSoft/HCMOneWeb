using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsleaveEncashment
    {
        public long InternalId { get; set; }
        public int? EmpId { get; set; }
        public string EmpName { get; set; }
        public decimal? BasicSalary { get; set; }
        public int? PeriodId { get; set; }
        public string PeriodName { get; set; }
        public int? LeaveId { get; set; }
        public int? ElementId { get; set; }
        public string LeaveType { get; set; }
        public DateTime? FromDt { get; set; }
        public DateTime? ToDate { get; set; }
        public decimal? TotalLeaves { get; set; }
        public decimal? TotalAmount { get; set; }
        public decimal? BalanceBf { get; set; }
        public decimal? Entitled { get; set; }
        public decimal? TotalAvailable { get; set; }
        public decimal? LeaveUsed { get; set; }
        public decimal? Requested { get; set; }
        public decimal? Approved { get; set; }
        public decimal? Balance { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDt { get; set; }
        public DateTime? UpdatedDt { get; set; }
        public string CalCode { get; set; }
        public string DocStatus { get; set; }
        public string DocAprStatus { get; set; }
        public int? DocNum { get; set; }
        public int? DocType { get; set; }
    }
}
