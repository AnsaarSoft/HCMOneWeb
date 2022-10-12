using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnDisciplinaryAppeal
    {
        public TrnDisciplinaryAppeal()
        {
            TrnsAppealEvidences = new HashSet<TrnsAppealEvidence>();
            TrnsDisciplinaryAppealEvidences = new HashSet<TrnsDisciplinaryAppealEvidence>();
        }

        public int Id { get; set; }
        public int? DisciplinaryActionId { get; set; }
        public string ReasonOfAppeal { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<TrnsAppealEvidence> TrnsAppealEvidences { get; set; }
        public virtual ICollection<TrnsDisciplinaryAppealEvidence> TrnsDisciplinaryAppealEvidences { get; set; }
    }
}
