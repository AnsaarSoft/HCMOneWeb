using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class AttSummary
    {
        public AttSummary()
        {
            AttSummaryDetails = new HashSet<AttSummaryDetail>();
        }

        public long AttSummaryId { get; set; }
        public int? PayrollId { get; set; }
        public int? PeriodId { get; set; }
        public string PeriodName { get; set; }
        public DateTime? CreateDt { get; set; }
        public DateTime? UpdateDt { get; set; }
        public string CreateBy { get; set; }
        public string UpdateBy { get; set; }
        public string Ip { get; set; }
        public DateTime? DocDate { get; set; }
        public string SourceType { get; set; }
        public long? SourceId { get; set; }
        public int? LeaveId { get; set; }
        public int? OvertimeId { get; set; }

        public virtual MstLeaveType Leave { get; set; }
        public virtual MstOverTime Overtime { get; set; }
        public virtual CfgPayrollDefination Payroll { get; set; }
        public virtual CfgPeriodDate Period { get; set; }
        public virtual ICollection<AttSummaryDetail> AttSummaryDetails { get; set; }
    }
}
