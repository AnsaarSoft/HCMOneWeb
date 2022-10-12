using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstLeaveType
    {
        public MstLeaveType()
        {
            AttSummaries = new HashSet<AttSummary>();
            CfgLeaveMatrices = new HashSet<CfgLeaveMatrix>();
            MstEmployeeLeaves = new HashSet<MstEmployeeLeaf>();
            TrnsAttendanceRegisters = new HashSet<TrnsAttendanceRegister>();
            TrnsLeavesRequests = new HashSet<TrnsLeavesRequest>();
            TrnsObleaves = new HashSet<TrnsObleaf>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int? DeductionId { get; set; }
        public string DeductionType { get; set; }
        public int? CarryForwardLeaves { get; set; }
        public bool? FlgEncash { get; set; }
        public bool? FlgAllowInProbation { get; set; }
        public bool? FlgActive { get; set; }
        public int? EncashmentCap { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? FlgNoticePeriod { get; set; }
        public bool? FlgPartiallyEncash { get; set; }
        public bool? FlgEndOfService { get; set; }
        public decimal? LeaveCap { get; set; }
        public bool? FlgCarryForward { get; set; }
        public bool? FlgProRate { get; set; }
        public DateTime? MonthCollapse { get; set; }
        public string ElementCode { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public virtual ICollection<AttSummary> AttSummaries { get; set; }
        public virtual ICollection<CfgLeaveMatrix> CfgLeaveMatrices { get; set; }
        public virtual ICollection<MstEmployeeLeaf> MstEmployeeLeaves { get; set; }
        public virtual ICollection<TrnsAttendanceRegister> TrnsAttendanceRegisters { get; set; }
        public virtual ICollection<TrnsLeavesRequest> TrnsLeavesRequests { get; set; }
        public virtual ICollection<TrnsObleaf> TrnsObleaves { get; set; }
    }
}
