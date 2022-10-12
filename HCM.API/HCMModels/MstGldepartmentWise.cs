using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstGldepartmentWise
    {
        public int Id { get; set; }
        public int? DepartmentId { get; set; }
        public int? SubDepartmentId { get; set; }
        public int? Gldid { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }
    }
}
