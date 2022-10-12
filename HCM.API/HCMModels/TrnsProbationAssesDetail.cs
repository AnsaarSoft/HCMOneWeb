using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsProbationAssesDetail
    {
        public int Id { get; set; }
        public int? HeadId { get; set; }
        public int? StatementId { get; set; }
        public int? Score { get; set; }
        public string Remarks { get; set; }

        public virtual TrnsProbationAssesHead Head { get; set; }
        public virtual MstProbationStatement Statement { get; set; }
    }
}
