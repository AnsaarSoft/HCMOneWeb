using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class EmployeeAssetAssignment
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public int? EmployeeRecoverId { get; set; }
        public string AssetGroupId { get; set; }
        public string AssetId { get; set; }
        public DateTime? AssignDate { get; set; }
        public DateTime? DateRecovered { get; set; }
        public bool? FlgActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public byte? DocType { get; set; }
        public string DocStatus { get; set; }
        public string DocAprStatus { get; set; }
        public int? DocNumber { get; set; }
        public string AssetClass { get; set; }
    }
}
