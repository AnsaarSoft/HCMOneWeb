using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsVacancyAssessmentStatement
    {
        public int Id { get; set; }
        public int StatementId { get; set; }
        public int VacancyId { get; set; }

        public virtual MstInterviewAssessmentQuestion Statement { get; set; }
        public virtual TrnsVacancyRequest Vacancy { get; set; }
    }
}
