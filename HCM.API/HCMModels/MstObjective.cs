using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstObjective
    {
        public MstObjective()
        {
            TrnsObjFnyHeads = new HashSet<TrnsObjFnyHead>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string MinWaight { get; set; }
        public string MaxWaight { get; set; }
        public string PayrollId { get; set; }
        public string CoEwaight { get; set; }
        public bool? FlgActive { get; set; }
        public int? Department { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public int? TermId { get; set; }

        public virtual MstCalendar Payroll { get; set; }
        public virtual ICollection<TrnsObjFnyHead> TrnsObjFnyHeads { get; set; }
    }
}
