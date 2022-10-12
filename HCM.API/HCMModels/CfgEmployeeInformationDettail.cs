using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class CfgEmployeeInformationDettail
    {
        public int Id { get; set; }
        public int? EmpElmtId { get; set; }
        public int? InformationId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? AdvanceAmount { get; set; }
        public decimal? ApplicableAmount { get; set; }
        public bool? FlgActive { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }
    }
}
