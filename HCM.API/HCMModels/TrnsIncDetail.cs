using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsIncDetail
    {
        public long Id { get; set; }
        public int? IncrId { get; set; }
        public int? EmpId { get; set; }
        public string EmpCode { get; set; }
        public string EmpName { get; set; }
        public decimal? CBasic { get; set; }
        public decimal? CGross { get; set; }
        public string ApplOn { get; set; }
        public string IncType { get; set; }
        public decimal? IncValue { get; set; }
        public decimal? NewBasic { get; set; }
        public decimal? NewGross { get; set; }
        public decimal? Arear { get; set; }
        public string Remarks { get; set; }
        public string CDesignation { get; set; }
        public string NDesignation { get; set; }
        public bool? FlgCurrentPeriod { get; set; }
        public bool? FlgDemotion { get; set; }

        public virtual MstEmployee Emp { get; set; }
        public virtual TrnsIncrementPromotion Incr { get; set; }
    }
}
