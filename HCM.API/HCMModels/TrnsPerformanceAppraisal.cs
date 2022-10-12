using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsPerformanceAppraisal
    {
        public TrnsPerformanceAppraisal()
        {
            TrnsPerformanceAppraisalDetails = new HashSet<TrnsPerformanceAppraisalDetail>();
        }

        public int Id { get; set; }
        public int? DocNum { get; set; }
        public DateTime? DocDate { get; set; }
        public byte? DocType { get; set; }
        public string DocStatus { get; set; }
        public int? Series { get; set; }
        public int? EmpId { get; set; }
        public string EmpName { get; set; }
        public DateTime? DateOfJoining { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public string Grade { get; set; }
        public int? PlanNumber { get; set; }
        public int? AppraiserId { get; set; }
        public string AppraiserName { get; set; }
        public string AppraiserPosition { get; set; }
        public string AppraiserDepartment { get; set; }
        public string Remarks { get; set; }
        public decimal? TotalScore { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }

        public virtual MstEmployee Appraiser { get; set; }
        public virtual MstEmployee Emp { get; set; }
        public virtual TrnsPerformancePlan PlanNumberNavigation { get; set; }
        public virtual ICollection<TrnsPerformanceAppraisalDetail> TrnsPerformanceAppraisalDetails { get; set; }
    }
}
