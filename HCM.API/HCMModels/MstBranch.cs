using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstBranch
    {
        public MstBranch()
        {
            MstCandidates = new HashSet<MstCandidate>();
            MstEmployees = new HashSet<MstEmployee>();
            MstMpps = new HashSet<MstMpp>();
            TrnsHeadBudgetDetails = new HashSet<TrnsHeadBudgetDetail>();
            TrnsInternalTransfers = new HashSet<TrnsInternalTransfer>();
            TrnsJobRequisitions = new HashSet<TrnsJobRequisition>();
            TrnsVacancyRequests = new HashSet<TrnsVacancyRequest>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }
        public int? SapdocEntry { get; set; }
        public string Prefix { get; set; }
        public bool? FlgActive { get; set; }
        public string RegionalHead { get; set; }

        public virtual ICollection<MstCandidate> MstCandidates { get; set; }
        public virtual ICollection<MstEmployee> MstEmployees { get; set; }
        public virtual ICollection<MstMpp> MstMpps { get; set; }
        public virtual ICollection<TrnsHeadBudgetDetail> TrnsHeadBudgetDetails { get; set; }
        public virtual ICollection<TrnsInternalTransfer> TrnsInternalTransfers { get; set; }
        public virtual ICollection<TrnsJobRequisition> TrnsJobRequisitions { get; set; }
        public virtual ICollection<TrnsVacancyRequest> TrnsVacancyRequests { get; set; }
    }
}
