using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstMpp
    {
        public MstMpp()
        {
            TrnsVacancyRequests = new HashSet<TrnsVacancyRequest>();
        }

        public int Id { get; set; }
        public int? DesignationId { get; set; }
        public int? BranchId { get; set; }
        public int? DepartmentId { get; set; }
        public short? OccupiedPositionsInitial { get; set; }
        public int? HeadCount { get; set; }
        public int? RemainingVacancy { get; set; }
        public int? Level { get; set; }
        public int? Parentcode { get; set; }
        public int? Company { get; set; }
        public int? Location { get; set; }
        public string Fiscalyear { get; set; }
        public string Description { get; set; }
        public bool? FlgActive { get; set; }
        public int? OpenVacancyCount { get; set; }
        public int? OccupiedPositionsCurrent { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public int? DesignationLevelId { get; set; }
        public int? ProjectId { get; set; }
        public string Project { get; set; }
        public string ProjectName { get; set; }
        public int? VacancyId { get; set; }
        public DateTime? VacancyExpiryDate { get; set; }
        public bool? FlgPublish { get; set; }

        public virtual MstBranch Branch { get; set; }
        public virtual MstDepartment Department { get; set; }
        public virtual MstDesignation Designation { get; set; }
        public virtual MstCalendar FiscalyearNavigation { get; set; }
        public virtual MstLocation LocationNavigation { get; set; }
        public virtual TrnsVacancyRequest Vacancy { get; set; }
        public virtual ICollection<TrnsVacancyRequest> TrnsVacancyRequests { get; set; }
    }
}
