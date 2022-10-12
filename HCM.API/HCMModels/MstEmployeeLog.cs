using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstEmployeeLog
    {
        public int Id { get; set; }
        public string Empid { get; set; }
        public int? PositionId { get; set; }
        public int? DepartmentId { get; set; }
        public int? LocationId { get; set; }
        public int? BranchId { get; set; }
        public int? DesigId { get; set; }
        public decimal? Salary { get; set; }
        public bool? Flgactive { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public DateTime? CutDate { get; set; }
        public int? Groupby { get; set; }
    }
}
