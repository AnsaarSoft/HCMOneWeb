using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsProductStageTeamLead
    {
        public int Id { get; set; }
        public int? Psid { get; set; }
        public string EmpCode { get; set; }
        public string EmpName { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }

        public virtual TrnsProductStage Ps { get; set; }
    }
}
