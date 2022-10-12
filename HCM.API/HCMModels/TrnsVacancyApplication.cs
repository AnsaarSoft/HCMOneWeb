using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsVacancyApplication
    {
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public int VacancyId { get; set; }
        public string Remarks { get; set; }
        public DateTime AppliedOn { get; set; }
        public long? Salary { get; set; }
        public string AppliedFor { get; set; }
        public string Branch { get; set; }
        public string ExtraCurr { get; set; }
        public string Achievements { get; set; }
        public DateTime AvailDate { get; set; }
        public bool Crime { get; set; }
        public string Details { get; set; }
        public bool Travel { get; set; }
        public string CareeaGoal { get; set; }
        public string Clientlimitation { get; set; }
        public string Traveling { get; set; }

        public virtual TrnsVacancyRequest Vacancy { get; set; }
    }
}
