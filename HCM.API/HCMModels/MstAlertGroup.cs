using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstAlertGroup
    {
        public MstAlertGroup()
        {
            CfgAlertManagementGroups = new HashSet<CfgAlertManagementGroup>();
            MstAlertGroupDetails = new HashSet<MstAlertGroupDetail>();
        }

        public int Id { get; set; }
        public string GroupCode { get; set; }
        public string GroupName { get; set; }
        public int? DocNum { get; set; }
        public bool? FlgActive { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<CfgAlertManagementGroup> CfgAlertManagementGroups { get; set; }
        public virtual ICollection<MstAlertGroupDetail> MstAlertGroupDetails { get; set; }
    }
}
