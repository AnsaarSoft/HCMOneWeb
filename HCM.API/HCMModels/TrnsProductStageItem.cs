using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsProductStageItem
    {
        public int Id { get; set; }
        public int? Psid { get; set; }
        public string ItemCode { get; set; }
        public string ItemDescription { get; set; }
        public string ItemGrpCode { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }

        public virtual TrnsProductStage Ps { get; set; }
    }
}
