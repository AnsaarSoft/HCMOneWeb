using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class CfgAlertManagement
    {
        public CfgAlertManagement()
        {
            CfgAlertManagementDepartments = new HashSet<CfgAlertManagementDepartment>();
            CfgAlertManagementEmployees = new HashSet<CfgAlertManagementEmployee>();
            CfgAlertManagementGroups = new HashSet<CfgAlertManagementGroup>();
            TrnsEmployeesAlerts = new HashSet<TrnsEmployeesAlert>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
        public string PriorityLovtype { get; set; }
        public bool? FlgActive { get; set; }
        public decimal? FrequencyValue { get; set; }
        public string FrequencyUnit { get; set; }
        public bool? FlgMessage { get; set; }
        public bool? FlgEmail { get; set; }
        public string ESubject { get; set; }
        public string EBody { get; set; }
        public string QueryName { get; set; }
        public DateTime? NextExecutionTime { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }

        public virtual ICollection<CfgAlertManagementDepartment> CfgAlertManagementDepartments { get; set; }
        public virtual ICollection<CfgAlertManagementEmployee> CfgAlertManagementEmployees { get; set; }
        public virtual ICollection<CfgAlertManagementGroup> CfgAlertManagementGroups { get; set; }
        public virtual ICollection<TrnsEmployeesAlert> TrnsEmployeesAlerts { get; set; }
    }
}
