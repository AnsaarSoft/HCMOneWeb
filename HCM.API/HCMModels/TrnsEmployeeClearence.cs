using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsEmployeeClearence
    {
        public TrnsEmployeeClearence()
        {
            TrnsEmployeeClearenceDetails = new HashSet<TrnsEmployeeClearenceDetail>();
        }

        public int Id { get; set; }
        public int? EmpId { get; set; }
        public int? ClearenceEmpId { get; set; }
        public string Receivable { get; set; }
        public bool? TimeSheetReceived { get; set; }
        public bool? EmailDeleted { get; set; }
        public bool? NotiPeriodServed { get; set; }
        public DateTime? NoticeFrom { get; set; }
        public DateTime? NoticeTo { get; set; }
        public string ClearenceFormType { get; set; }
        public byte? DocNum { get; set; }
        public int? DocType { get; set; }
        public string DocStatus { get; set; }
        public string DocAprStatus { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        public virtual MstEmployee Emp { get; set; }
        public virtual ICollection<TrnsEmployeeClearenceDetail> TrnsEmployeeClearenceDetails { get; set; }
    }
}
