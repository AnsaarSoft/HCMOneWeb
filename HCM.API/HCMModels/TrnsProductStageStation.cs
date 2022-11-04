using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsProductStageStation
    {
        public int Id { get; set; }
        public int? Psid { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }

        public virtual TrnsProductStage Ps { get; set; }
    }
}
