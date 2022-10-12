using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsTaxAdjustmentDetail
    {
        public int Id { get; set; }
        public int? Taid { get; set; }
        public string Description { get; set; }
        public decimal? Amount { get; set; }
        public bool? FlgActive { get; set; }
        public bool? FlgMonthly { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreateDt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdateDt { get; set; }

        public virtual TrnsTaxAdjustment Ta { get; set; }
    }
}
