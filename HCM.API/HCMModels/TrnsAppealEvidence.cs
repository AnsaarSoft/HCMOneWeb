using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsAppealEvidence
    {
        public int Id { get; set; }
        public int? AppealId { get; set; }
        public string EvidencePath { get; set; }
        public string EvidenceExtension { get; set; }
        public string EvidenceDescription { get; set; }

        public virtual TrnDisciplinaryAppeal Appeal { get; set; }
    }
}
