using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstShiftDay
    {
        public int InternalId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int? DaysCount { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
