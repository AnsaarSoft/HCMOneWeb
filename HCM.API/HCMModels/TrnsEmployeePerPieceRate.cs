using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsEmployeePerPieceRate
    {
        public TrnsEmployeePerPieceRate()
        {
            TrnsEmployeePerPieceRateDetails = new HashSet<TrnsEmployeePerPieceRateDetail>();
        }

        public int InternalId { get; set; }
        public int? EmpId { get; set; }
        public DateTime? CreateDt { get; set; }
        public DateTime? UpdateDt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public virtual MstEmployee Emp { get; set; }
        public virtual ICollection<TrnsEmployeePerPieceRateDetail> TrnsEmployeePerPieceRateDetails { get; set; }
    }
}
