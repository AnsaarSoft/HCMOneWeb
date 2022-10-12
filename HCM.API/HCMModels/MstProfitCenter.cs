using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstProfitCenter
    {
        public int InternalId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool? FlgActive { get; set; }
        public bool? FlgDelete { get; set; }
        public DateTime? CreateDt { get; set; }
        public DateTime? UpdateDt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
