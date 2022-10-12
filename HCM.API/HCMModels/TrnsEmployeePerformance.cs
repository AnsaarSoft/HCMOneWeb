using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsEmployeePerformance
    {
        public TrnsEmployeePerformance()
        {
            TrnsEmployeePerformanceDetails = new HashSet<TrnsEmployeePerformanceDetail>();
        }

        public int Id { get; set; }
        public int? PayrollId { get; set; }
        public int? PeriodId { get; set; }
        public int? ElementId { get; set; }
        public decimal? AllowancePercentage { get; set; }
        public string DocStatus { get; set; }
        public int? DocNum { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public virtual ICollection<TrnsEmployeePerformanceDetail> TrnsEmployeePerformanceDetails { get; set; }
    }
}
