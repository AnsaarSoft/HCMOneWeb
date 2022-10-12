using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstCandidateEducation
    {
        public int Id { get; set; }
        public int CandidateRef { get; set; }
        public int? InstituteId { get; set; }
        public string InstituteName { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string Subject { get; set; }
        public int? QualificationId { get; set; }
        public string AwardedQualification { get; set; }
        public string MarksGrades { get; set; }
        public string Notes { get; set; }
        public int? NoPaperPassed { get; set; }
        public DateTime? DateofFirstAttempt { get; set; }
        public DateTime? DateofLastAttempt { get; set; }
        public int? TotalAttempts { get; set; }
        public bool? Accaaffiliate { get; set; }
        public bool? Accafinalist { get; set; }
        public bool? Icapcaf { get; set; }
        public bool? Icapafc { get; set; }
        public bool? Cmaqualified { get; set; }
        public int? Ftsid { get; set; }
        public string Ftsname { get; set; }

        public virtual MstCandidate CandidateRefNavigation { get; set; }
    }
}
