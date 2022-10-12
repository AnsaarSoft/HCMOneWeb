using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsJe
    {
        public TrnsJe()
        {
            TrnsJedetails = new HashSet<TrnsJedetail>();
        }

        public int Id { get; set; }
        public DateTime? CreateDt { get; set; }
        public DateTime? UpdateDt { get; set; }
        public DateTime? JepostingDate { get; set; }
        public int? PayrollId { get; set; }
        public int? PeriodId { get; set; }
        public string Memo { get; set; }
        public int? SbojeNum { get; set; }
        public bool? FlgCanceled { get; set; }
        public bool? FlgPosted { get; set; }
        public bool? IntSboTransfered { get; set; }
        public bool? IntSboPublished { get; set; }
        public string Source { get; set; }
        public bool? FlgDisburseStatus { get; set; }
        public int? DisbursedId { get; set; }

        public virtual CfgPayrollDefination Payroll { get; set; }
        public virtual CfgPeriodDate Period { get; set; }
        public virtual ICollection<TrnsJedetail> TrnsJedetails { get; set; }
    }
}
