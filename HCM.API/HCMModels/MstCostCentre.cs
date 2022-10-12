using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstCostCentre
    {
        public int Id { get; set; }
        public string CostCentreCode { get; set; }
        public string CostCentreDesc { get; set; }
        public bool? FlgActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
