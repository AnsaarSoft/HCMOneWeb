using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstTarget
    {
        public int Id { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public decimal? FrmPieces { get; set; }
        public decimal? ToPieces { get; set; }
        public decimal? FixValue { get; set; }
        public int? Psid { get; set; }
        public string Pscode { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UserId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdatedBy { get; set; }

        public virtual TrnsProductStage Ps { get; set; }
    }
}
