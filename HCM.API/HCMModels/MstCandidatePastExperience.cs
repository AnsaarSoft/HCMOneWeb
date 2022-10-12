using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstCandidatePastExperience
    {
        public int Id { get; set; }
        public int? CandidateRef { get; set; }
        public string Company { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string Position { get; set; }
        public string Duties { get; set; }
        public string Notes { get; set; }
        public string LastSalary { get; set; }
        public bool? IsPresent { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Department { get; set; }
        public double? NoticePeriod { get; set; }

        public virtual MstCandidate CandidateRefNavigation { get; set; }
    }
}
