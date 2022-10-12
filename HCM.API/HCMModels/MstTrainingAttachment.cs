using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstTrainingAttachment
    {
        public int Id { get; set; }
        public int? TrainingId { get; set; }
        public string DocName { get; set; }
        public string Extention { get; set; }
        public string DocContent { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? FlgActive { get; set; }
        public bool? Deteled { get; set; }

        public virtual TrnsTrainingPlan Training { get; set; }
    }
}
