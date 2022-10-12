using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstInterviewAssessmentCategory
    {
        public MstInterviewAssessmentCategory()
        {
            MstInterviewAssessmentQuestions = new HashSet<MstInterviewAssessmentQuestion>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? Active { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? FlgDetailPart { get; set; }

        public virtual ICollection<MstInterviewAssessmentQuestion> MstInterviewAssessmentQuestions { get; set; }
    }
}
