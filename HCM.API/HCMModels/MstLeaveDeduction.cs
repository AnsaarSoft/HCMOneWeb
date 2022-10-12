using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstLeaveDeduction
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string TypeofDeduction { get; set; }
        public decimal? DeductionValue { get; set; }
        public bool? DeductionStatus { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdateBy { get; set; }
        public bool? FlgActive { get; set; }
    }
}
