using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class LogDisbursment
    {
        public int InternalId { get; set; }
        public string EmpId { get; set; }
        public string PayrollName { get; set; }
        public string PeriodName { get; set; }
        public int? OpdocEntry { get; set; }
        public int? Opseries { get; set; }
        public string PaidLocation { get; set; }
        public string EntryType { get; set; }
        public string EntrySource { get; set; }
        public string Remarks { get; set; }
        public string Attachement { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? BaseEntry { get; set; }
        public string LogStatus { get; set; }
    }
}
