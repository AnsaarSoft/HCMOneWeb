using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstCandidateQualification
    {
        public int Id { get; set; }
        public int? CandidateRef { get; set; }
        public int? CertificationId { get; set; }
        public string Awardedby { get; set; }
        public string AwardStatus { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public string Validated { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Ftsid { get; set; }
        public string Ftsname { get; set; }

        public virtual MstCandidate CandidateRefNavigation { get; set; }
    }
}
