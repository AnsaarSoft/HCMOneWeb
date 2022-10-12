using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsJobAdvertising
    {
        public int Id { get; set; }
        public int? JrdocId { get; set; }
        public int? Jrseries { get; set; }
        public bool? FlgInternal { get; set; }
        public bool? FlgExternal { get; set; }
        public bool? FlgRecruiter { get; set; }
        public string AdvertiseMedium { get; set; }
        public int? PreferredRecruiters { get; set; }
        public string Remarks { get; set; }
        public DateTime? CreateDt { get; set; }
        public string UserId { get; set; }
        public DateTime? UpdateDt { get; set; }
        public string UpdatedBy { get; set; }

        public virtual TrnsJobRequisition Jrdoc { get; set; }
        public virtual MstRecruiter PreferredRecruitersNavigation { get; set; }
    }
}
