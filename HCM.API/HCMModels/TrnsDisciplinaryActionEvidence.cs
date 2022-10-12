using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsDisciplinaryActionEvidence
    {
        public int Id { get; set; }
        public int? DisciplinaryActionId { get; set; }
        public string FileExtension { get; set; }
        public string FilePath { get; set; }
        public string EvidenceDescription { get; set; }

        public virtual TrnsDisciplinaryActionRequest DisciplinaryAction { get; set; }
    }
}
