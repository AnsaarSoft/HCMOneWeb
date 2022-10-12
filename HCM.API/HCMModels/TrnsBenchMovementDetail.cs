using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsBenchMovementDetail
    {
        public int Id { get; set; }
        public int? OnBenchEmpId { get; set; }
        public int? OnBoardEmpId { get; set; }
        public string DesignationName { get; set; }
        public string BranchName { get; set; }
        public string DepartmentName { get; set; }
        public string ProjectName { get; set; }
        public int? BenchId { get; set; }
        public int? RegionalHeadId { get; set; }
        public string RegionalHeadName { get; set; }
        public bool? SendToRegionalHead { get; set; }
        public bool? AssetsRecovered { get; set; }
        public string OnBenchEmpName { get; set; }

        public virtual TrnsBenchMovement Bench { get; set; }
    }
}
