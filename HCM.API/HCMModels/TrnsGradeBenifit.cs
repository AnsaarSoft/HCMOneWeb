using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsGradeBenifit
    {
        public int Id { get; set; }
        public int? GradeId { get; set; }
        public int? BenifitId { get; set; }
        public bool? FlgActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public virtual MstBenefit Benifit { get; set; }
        public virtual MstGrading Grade { get; set; }
    }
}
