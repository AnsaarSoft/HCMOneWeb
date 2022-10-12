using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsPerformanceManagement
    {
        public int Id { get; set; }
        public int? Empid { get; set; }
        public string AppraiserComments { get; set; }
        public string SupervisorComments { get; set; }
        public string AppraiseeComments { get; set; }
        public string HrComments { get; set; }
        public int? FinalScore { get; set; }
        public string FinalRating { get; set; }
        public decimal? IncrementPercentage { get; set; }
        public int? YearId { get; set; }
        public string DocStatus { get; set; }
        public string DocAprStatus { get; set; }
        public int? DocType { get; set; }
        public int? DocNumber { get; set; }
        public decimal? AnomalyPercentage { get; set; }
        public decimal? AnamolyAmount { get; set; }

        public virtual MstEmployee Emp { get; set; }
    }
}
