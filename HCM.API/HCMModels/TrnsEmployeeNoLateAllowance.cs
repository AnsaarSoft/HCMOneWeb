using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsEmployeeNoLateAllowance
    {
        public TrnsEmployeeNoLateAllowance()
        {
            TrnsEmployeeNoLateAllowanceDetails = new HashSet<TrnsEmployeeNoLateAllowanceDetail>();
        }

        public int InternalId { get; set; }
        public int? DocNum { get; set; }
        public bool DocStatus { get; set; }
        public int? CalculatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? PaysThrough { get; set; }

        public virtual ICollection<TrnsEmployeeNoLateAllowanceDetail> TrnsEmployeeNoLateAllowanceDetails { get; set; }
    }
}
