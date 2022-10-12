using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstInterviewAssessmentQuestion
    {
        public MstInterviewAssessmentQuestion()
        {
            TrnsVacancyAssessmentStatements = new HashSet<TrnsVacancyAssessmentStatement>();
        }

        public int Id { get; set; }
        public int InterviewAssessmentCategoryId { get; set; }
        public string Statement { get; set; }
        public bool? Active { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? DesignationId { get; set; }
        public int? VacancyId { get; set; }

        public virtual MstInterviewAssessmentCategory InterviewAssessmentCategory { get; set; }
        public virtual ICollection<TrnsVacancyAssessmentStatement> TrnsVacancyAssessmentStatements { get; set; }
    }
}
