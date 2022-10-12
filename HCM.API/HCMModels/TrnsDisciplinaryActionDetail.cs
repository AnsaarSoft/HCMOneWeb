using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsDisciplinaryActionDetail
    {
        public int Id { get; set; }
        public int? DisciplinaryActionId { get; set; }
        public int? ActionAgainst { get; set; }
        public bool? FlgTermination { get; set; }
        public bool? FlgDownGrading { get; set; }
        public bool? FlgWarning { get; set; }
        public bool? FlgVerbalWarning { get; set; }
        public bool? FlgFirstWarning { get; set; }
        public bool? FlgLastWarning { get; set; }

        public virtual MstEmployee ActionAgainstNavigation { get; set; }
        public virtual TrnsDisciplinaryActionRequest DisciplinaryAction { get; set; }
    }
}
