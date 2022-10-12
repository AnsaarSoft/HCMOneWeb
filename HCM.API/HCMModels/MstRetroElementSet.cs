using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstRetroElementSet
    {
        public MstRetroElementSet()
        {
            MstRetroElementDetails = new HashSet<MstRetroElementDetail>();
        }

        public int Id { get; set; }
        public string RetroSetCode { get; set; }
        public string RetroSetName { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }

        public virtual ICollection<MstRetroElementDetail> MstRetroElementDetails { get; set; }
    }
}
