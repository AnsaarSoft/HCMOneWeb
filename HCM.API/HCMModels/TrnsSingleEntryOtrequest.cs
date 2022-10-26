using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsSingleEntryOtrequest
    {
        public TrnsSingleEntryOtrequest()
        {
            TrnsSingleEntryOtdetails = new HashSet<TrnsSingleEntryOtdetail>();
        }

        public int Id { get; set; }
        public int? DocNum { get; set; }
        public int? PayrollId { get; set; }
        public int? PeriodId { get; set; }
        public int? Ottype { get; set; }
        public string DocStatus { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string DcStatus { get; set; }
        public string DocAprStatus { get; set; }
        public int? DocType { get; set; }
        public string OttypeDescription { get; set; }

        public virtual MstOverTime OttypeNavigation { get; set; }
        public virtual CfgPayrollDefination Payroll { get; set; }
        public virtual CfgPeriodDate Period { get; set; }
        public virtual ICollection<TrnsSingleEntryOtdetail> TrnsSingleEntryOtdetails { get; set; }
    }
}
