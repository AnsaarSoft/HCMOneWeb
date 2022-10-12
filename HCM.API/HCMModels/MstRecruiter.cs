using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstRecruiter
    {
        public MstRecruiter()
        {
            TrnsJobAdvertisings = new HashSet<TrnsJobAdvertising>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Recruiter { get; set; }
        public DateTime? CreateDt { get; set; }
        public string UserId { get; set; }
        public DateTime? UpdateDt { get; set; }
        public string UpdatedBy { get; set; }

        public virtual ICollection<TrnsJobAdvertising> TrnsJobAdvertisings { get; set; }
    }
}
