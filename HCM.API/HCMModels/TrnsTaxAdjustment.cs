using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsTaxAdjustment
    {
        public TrnsTaxAdjustment()
        {
            TrnsTaxAdjustmentDetails = new HashSet<TrnsTaxAdjustmentDetail>();
        }

        public int Id { get; set; }
        public int? EmpId { get; set; }
        public int? CalendarId { get; set; }
        public bool? FlgActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreateDt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdateDt { get; set; }
        public string CalendarCode { get; set; }
        public string EmpCode { get; set; }

        public virtual MstCalendar Calendar { get; set; }
        public virtual MstEmployee Emp { get; set; }
        public virtual ICollection<TrnsTaxAdjustmentDetail> TrnsTaxAdjustmentDetails { get; set; }
    }
}
