using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsOtslab
    {
        public TrnsOtslab()
        {
            MstEmployees = new HashSet<MstEmployee>();
            TrnsOtslabDetails = new HashSet<TrnsOtslabDetail>();
        }

        public int InternalId { get; set; }
        public string SlabCode { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreateDt { get; set; }
        public DateTime? UpdateDt { get; set; }

        public virtual ICollection<MstEmployee> MstEmployees { get; set; }
        public virtual ICollection<TrnsOtslabDetail> TrnsOtslabDetails { get; set; }
    }
}
