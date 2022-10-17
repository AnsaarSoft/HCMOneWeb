using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstGoalsRuless
    {
        public int Id { get; set; }
        public int? MinimumGoals { get; set; }
        public int? MaximumGoals { get; set; }
        public string YearId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdateBy { get; set; }

        public virtual MstCalendar Year { get; set; }
    }
}
