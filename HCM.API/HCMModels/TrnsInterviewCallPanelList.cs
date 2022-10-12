using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsInterviewCallPanelList
    {
        public int Id { get; set; }
        public int? Icid { get; set; }
        public int? EmpId { get; set; }
        public DateTime? CreateDt { get; set; }
        public DateTime? UpdateDt { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }

        public virtual MstEmployee Emp { get; set; }
        public virtual TrnsInterviewCall Ic { get; set; }
    }
}
