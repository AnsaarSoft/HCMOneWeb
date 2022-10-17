using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstStageDetail
    {
        public int Id { get; set; }
        public int? StageId { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool? FlgDeleted { get; set; }
        public string EmpId { get; set; }

        public virtual MstEmployee Employee { get; set; }
        public virtual MstStage Stage { get; set; }
    }
}
