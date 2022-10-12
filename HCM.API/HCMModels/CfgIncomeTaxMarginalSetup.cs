using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class CfgIncomeTaxMarginalSetup
    {
        public int Id { get; set; }
        public decimal? MaxAmount { get; set; }
        public decimal? MinAmount { get; set; }
        public decimal? Rate { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }
    }
}
