using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsEmployeeOvertime
    {
        public TrnsEmployeeOvertime()
        {
            TrnsEmployeeOvertimeDetails = new HashSet<TrnsEmployeeOvertimeDetail>();
        }

        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public int? Period { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }
        public decimal? AttendanceId { get; set; }
        public int? DocNum { get; set; }
        public int? DocType { get; set; }
        public string DocStatus { get; set; }
        public string DocAprStatus { get; set; }
        public string Remarks { get; set; }

        public virtual MstEmployee Employee { get; set; }
        public virtual CfgPeriodDate PeriodNavigation { get; set; }
        public virtual ICollection<TrnsEmployeeOvertimeDetail> TrnsEmployeeOvertimeDetails { get; set; }
    }
}
