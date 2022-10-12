using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstArrear
    {
        public MstArrear()
        {
            TrnsObarrears = new HashSet<TrnsObarrear>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool? FlgActive { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }

        public virtual ICollection<TrnsObarrear> TrnsObarrears { get; set; }
    }
}
