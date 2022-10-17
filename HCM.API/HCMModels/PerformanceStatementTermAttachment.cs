using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class PerformanceStatementTermAttachment
    {
        public int Id { get; set; }
        public int? StatementId { get; set; }
        public int? TermId { get; set; }
        public string YearId { get; set; }
        public decimal? Weightage { get; set; }
        public int? DocNum { get; set; }
        public string DocStatus { get; set; }
        public string DocAprStatus { get; set; }
        public int? DocType { get; set; }
        public decimal? Actual { get; set; }
        public decimal? Percentage { get; set; }
        public int? EmpId { get; set; }
        public string HowToAchieve { get; set; }

        public virtual MstSubPartsStatement Statement { get; set; }
        public virtual MstPerformanceTerm Term { get; set; }
        public virtual MstCalendar Year { get; set; }
    }
}
