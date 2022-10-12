using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstStation
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool? FlgActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
