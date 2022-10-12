using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsInterviewCallActivity
    {
        public int Id { get; set; }
        public int? Icid { get; set; }
        public int? HandledbyEmpId { get; set; }
        public DateTime? ActivityDt { get; set; }
        public string ActivityContent { get; set; }
        public DateTime? CreateDt { get; set; }
        public string UserId { get; set; }
        public DateTime? UpdateDt { get; set; }
        public string UpdatedBy { get; set; }
        public string Recurrence { get; set; }

        public virtual MstEmployee HandledbyEmp { get; set; }
        public virtual TrnsInterviewCall Ic { get; set; }
    }
}
