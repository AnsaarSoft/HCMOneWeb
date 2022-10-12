using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsEmployeeAttendanceAllowance
    {
        public TrnsEmployeeAttendanceAllowance()
        {
            TrnsEmployeeAttendanceAllowanceDetails = new HashSet<TrnsEmployeeAttendanceAllowanceDetail>();
        }

        public int InternalId { get; set; }
        public int? DocNum { get; set; }
        public bool DocStatus { get; set; }
        public int? CalculatedOn { get; set; }
        public int? PaysThrough { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual MstElement CalculatedOnNavigation { get; set; }
        public virtual ICollection<TrnsEmployeeAttendanceAllowanceDetail> TrnsEmployeeAttendanceAllowanceDetails { get; set; }
    }
}
