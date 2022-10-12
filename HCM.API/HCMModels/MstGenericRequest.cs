using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstGenericRequest
    {
        public MstGenericRequest()
        {
            TrnsGenericRequests = new HashSet<TrnsGenericRequest>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public bool? FlgActive { get; set; }
        public string Code { get; set; }

        public virtual ICollection<TrnsGenericRequest> TrnsGenericRequests { get; set; }
    }
}
