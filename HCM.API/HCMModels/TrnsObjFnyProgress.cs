using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsObjFnyProgress
    {
        public int Id { get; set; }
        public string SelfProgress { get; set; }
        public string SupervisorProgress { get; set; }
        public int? FkObjDetailId { get; set; }

        public virtual TrnsObjFnyDetail FkObjDetail { get; set; }
    }
}
