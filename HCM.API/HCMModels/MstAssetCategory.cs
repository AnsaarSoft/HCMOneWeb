using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstAssetCategory
    {
        public short Code { get; set; }
        public string Description { get; set; }
        public bool? Active { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
