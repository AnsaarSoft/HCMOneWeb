using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsDisciplinaryActionWitnessess
    {
        public int Id { get; set; }
        public int? DisciplianryActionId { get; set; }
        public int? Witness { get; set; }

        public virtual TrnsDisciplinaryActionRequest DisciplianryAction { get; set; }
        public virtual MstEmployee WitnessNavigation { get; set; }
    }
}
