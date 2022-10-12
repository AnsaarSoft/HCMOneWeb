using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstElementQueryRegister
    {
        public int InternalId { get; set; }
        public string ElementCode { get; set; }
        public string QueryName { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
