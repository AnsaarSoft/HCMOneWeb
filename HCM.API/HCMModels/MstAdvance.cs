using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstAdvance
    {
        public MstAdvance()
        {
            TrnsAdvances = new HashSet<TrnsAdvance>();
            TrnsEmployeeElementAdvances = new HashSet<TrnsEmployeeElementAdvance>();
        }

        public int Id { get; set; }
        public string AllowanceId { get; set; }
        public string Description { get; set; }
        public bool? FlgActive { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }
        public bool? FlgDefault { get; set; }
        public bool? FlgPettyCash { get; set; }
        public int? MaxAllowed { get; set; }
        public int? DedElementId { get; set; }
        public int? EarElementId { get; set; }

        public virtual ICollection<TrnsAdvance> TrnsAdvances { get; set; }
        public virtual ICollection<TrnsEmployeeElementAdvance> TrnsEmployeeElementAdvances { get; set; }
    }
}
