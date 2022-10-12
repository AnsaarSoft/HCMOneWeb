using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class EmployeeAssetAssign
    {
        public int Id { get; set; }
        public int? EmployeeCode { get; set; }
        public int? EmployeeRecoverId { get; set; }
        public int? AssetId { get; set; }
        public DateTime? AssingDate { get; set; }
        public DateTime? DateRecovered { get; set; }
        public bool? HrActive { get; set; }
        public bool? FlgActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public virtual MstEmployeeAsset Asset { get; set; }
        public virtual MstEmployee EmployeeCodeNavigation { get; set; }
    }
}
