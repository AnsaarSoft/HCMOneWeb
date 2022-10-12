using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstAlertGroupDetail
    {
        public int Id { get; set; }
        public int? AlertGroupId { get; set; }
        public string EmpName { get; set; }
        public int? EmpId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual MstAlertGroup AlertGroup { get; set; }
        public virtual MstEmployee Emp { get; set; }
    }
}
