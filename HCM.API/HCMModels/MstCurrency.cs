using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstCurrency
    {
        public short Code { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? Active { get; set; }
    }
}
