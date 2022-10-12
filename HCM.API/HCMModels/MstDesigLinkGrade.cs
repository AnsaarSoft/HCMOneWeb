using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstDesigLinkGrade
    {
        public int Id { get; set; }
        public int? DesignationId { get; set; }
        public int? GradeId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public bool? FlgActive { get; set; }

        public virtual MstDesignation Designation { get; set; }
        public virtual MstGrading Grade { get; set; }
    }
}
