using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsElementPerRateDetail
    {
        public int Id { get; set; }
        public int? Fkid { get; set; }
        public int? EmpId { get; set; }
        public decimal? Count { get; set; }
        public decimal? Rate { get; set; }
        public decimal? Amount { get; set; }

        public virtual TrnsElementPerRate Fk { get; set; }
    }
}
