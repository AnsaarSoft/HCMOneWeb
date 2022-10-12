using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstProbationStatementsChildDesignation
    {
        public int Id { get; set; }
        public int? ProbationStatementId { get; set; }
        public int? DesignationId { get; set; }
        public string DesignationName { get; set; }

        public virtual MstDesignation Designation { get; set; }
        public virtual MstProbationStatement ProbationStatement { get; set; }
    }
}
