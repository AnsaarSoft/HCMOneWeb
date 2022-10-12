using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsJrdetailEducation
    {
        public int Id { get; set; }
        public int? Jrid { get; set; }
        public int? EducationType { get; set; }
        public string Description { get; set; }
        public string Major { get; set; }
        public string Diploma { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }

        public virtual MstQualification EducationTypeNavigation { get; set; }
        public virtual TrnsJobRequisition Jr { get; set; }
    }
}
