using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsEmpVl
    {
        public TrnsEmpVl()
        {
            TrnsEmpVldetails = new HashSet<TrnsEmpVldetail>();
            TrnsVlEntitlements = new HashSet<TrnsVlEntitlement>();
        }

        public long EmpVlId { get; set; }
        public int? Empid { get; set; }
        public DateTime? EmpJoinDate { get; set; }
        public DateTime? EmpVlStartDate { get; set; }
        public decimal? Bfbalance { get; set; }
        public DateTime? Bfdate { get; set; }
        public int? PeriodId { get; set; }

        public virtual MstEmployee Emp { get; set; }
        public virtual ICollection<TrnsEmpVldetail> TrnsEmpVldetails { get; set; }
        public virtual ICollection<TrnsVlEntitlement> TrnsVlEntitlements { get; set; }
    }
}
