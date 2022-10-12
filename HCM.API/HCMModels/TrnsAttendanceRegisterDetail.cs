using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsAttendanceRegisterDetail
    {
        public int Id { get; set; }
        public int? Fkid { get; set; }
        public string TimeInCc { get; set; }
        public string TimeOutCc { get; set; }
        public decimal? TotalHours { get; set; }
        public string CostCenter { get; set; }

        public virtual TrnsAttendanceRegister Fk { get; set; }
    }
}
