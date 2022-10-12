using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstLocation
    {
        public MstLocation()
        {
            MstCandidates = new HashSet<MstCandidate>();
            MstEmployees = new HashSet<MstEmployee>();
            MstMpps = new HashSet<MstMpp>();
            MstStages = new HashSet<MstStage>();
            TrnsEmployeeArrears = new HashSet<TrnsEmployeeArrear>();
            TrnsEmployeeWorkDays = new HashSet<TrnsEmployeeWorkDay>();
            TrnsHeadBudgets = new HashSet<TrnsHeadBudget>();
            TrnsInternalTransfers = new HashSet<TrnsInternalTransfer>();
            TrnsJobRequisitions = new HashSet<TrnsJobRequisition>();
            TrnsVacancyRequests = new HashSet<TrnsVacancyRequest>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CostCenter { get; set; }
        public string AttandanceId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }
        public string TradeLicenseNo { get; set; }
        public string BankCode { get; set; }
        public bool? FlgActive { get; set; }
        public int? LocationTypeId { get; set; }
        public string LocationType { get; set; }
        public int? SbodocEntry { get; set; }

        public virtual ICollection<MstCandidate> MstCandidates { get; set; }
        public virtual ICollection<MstEmployee> MstEmployees { get; set; }
        public virtual ICollection<MstMpp> MstMpps { get; set; }
        public virtual ICollection<MstStage> MstStages { get; set; }
        public virtual ICollection<TrnsEmployeeArrear> TrnsEmployeeArrears { get; set; }
        public virtual ICollection<TrnsEmployeeWorkDay> TrnsEmployeeWorkDays { get; set; }
        public virtual ICollection<TrnsHeadBudget> TrnsHeadBudgets { get; set; }
        public virtual ICollection<TrnsInternalTransfer> TrnsInternalTransfers { get; set; }
        public virtual ICollection<TrnsJobRequisition> TrnsJobRequisitions { get; set; }
        public virtual ICollection<TrnsVacancyRequest> TrnsVacancyRequests { get; set; }
    }
}
