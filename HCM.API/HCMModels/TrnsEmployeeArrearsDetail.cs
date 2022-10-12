using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsEmployeeArrearsDetail
    {
        public int Id { get; set; }
        public int? EmpArrearId { get; set; }
        public int? EmployeeId { get; set; }
        public bool? FlgActive { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }

        public virtual TrnsEmployeeArrear EmpArrear { get; set; }
    }
}
