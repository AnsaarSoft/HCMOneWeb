using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstEmployeeEducation
    {
        public int Id { get; set; }
        public int? EmpId { get; set; }
        public int? InstituteId { get; set; }
        public string InstituteName { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string Subject { get; set; }
        public int? QualificationId { get; set; }
        public string QualificationName { get; set; }
        public string AwardedQualification { get; set; }
        public string MarkGrade { get; set; }
        public string Notes { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }

        public virtual MstEmployee Emp { get; set; }
        public virtual MstInstitute Institute { get; set; }
        public virtual MstQualification Qualification { get; set; }
    }
}
