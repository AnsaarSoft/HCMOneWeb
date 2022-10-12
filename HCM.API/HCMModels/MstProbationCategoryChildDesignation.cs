using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstProbationCategoryChildDesignation
    {
        public int Id { get; set; }
        public int? ProbationId { get; set; }
        public int? DesignationId { get; set; }
        public string DesignationName { get; set; }

        public virtual MstDesignation Designation { get; set; }
        public virtual MstProbationCategory Probation { get; set; }
    }
}
