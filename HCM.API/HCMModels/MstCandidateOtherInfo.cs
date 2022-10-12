using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstCandidateOtherInfo
    {
        public int Id { get; set; }
        public string ExtraCurr { get; set; }
        public string Achievements { get; set; }
        public DateTime AvailDate { get; set; }
        public bool Crime { get; set; }
        public string Details { get; set; }
        public bool Travel { get; set; }
        public string CareeaGoal { get; set; }
        public string Clientlimitation { get; set; }
        public int? CandidateRef { get; set; }
        public int? VacancyRef { get; set; }
    }
}
