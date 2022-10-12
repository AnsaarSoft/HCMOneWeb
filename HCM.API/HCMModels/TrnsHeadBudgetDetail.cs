using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsHeadBudgetDetail
    {
        public int Id { get; set; }
        public int? BudgetId { get; set; }
        public int? DesignationId { get; set; }
        public string Designation { get; set; }
        public int? BranchId { get; set; }
        public string Branch { get; set; }
        public int? DepartmentId { get; set; }
        public string Department { get; set; }
        public short? BudgetedHearcount { get; set; }
        public short? OccupiedPositions { get; set; }

        public virtual MstBranch BranchNavigation { get; set; }
        public virtual TrnsHeadBudget Budget { get; set; }
        public virtual MstDepartment DepartmentNavigation { get; set; }
        public virtual MstDesignation DesignationNavigation { get; set; }
    }
}
