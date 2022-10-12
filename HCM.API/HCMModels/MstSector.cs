using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstSector
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string CreatedBy { get; set; }
        public bool? FlgActive { get; set; }
    }
}
