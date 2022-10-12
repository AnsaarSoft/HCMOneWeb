using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsJrdetailCompetancy
    {
        public int Id { get; set; }
        public int? Jrid { get; set; }
        public int? CompetancyId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Remarks { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }

        public virtual MstCompetancy Competancy { get; set; }
        public virtual TrnsJobRequisition Jr { get; set; }
    }
}
