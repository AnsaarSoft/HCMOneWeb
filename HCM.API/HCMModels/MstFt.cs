using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstFt
    {
        public int Id { get; set; }
        public string No { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? FlgActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int UpdatedBy { get; set; }
    }
}
