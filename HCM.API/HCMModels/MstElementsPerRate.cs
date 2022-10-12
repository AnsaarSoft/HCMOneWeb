using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstElementsPerRate
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string ElemType { get; set; }
        public string ValueType { get; set; }
        public decimal? ElemValue { get; set; }
        public string ElemFunction { get; set; }
        public int? PayThrough { get; set; }
        public string DayWeek { get; set; }
        public bool? FlgActive { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
