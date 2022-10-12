using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsLeavesRequest
    {
        public TrnsLeavesRequest()
        {
            TrnsLeaveRequestHistories = new HashSet<TrnsLeaveRequestHistory>();
        }

        public int Id { get; set; }
        public int? EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpDesg { get; set; }
        public string EmpDept { get; set; }
        public string EmpLoc { get; set; }
        public int? DocNum { get; set; }
        public string DocStatus { get; set; }
        public string DocAprStatus { get; set; }
        public string LeaveDescription { get; set; }
        public DateTime? DocDate { get; set; }
        public DateTime? LeaveFrom { get; set; }
        public DateTime? LeaveTo { get; set; }
        public string FromTime { get; set; }
        public string ToTime { get; set; }
        public int? LeaveType { get; set; }
        public string Value { get; set; }
        public decimal? TotalCount { get; set; }
        public string CalCode { get; set; }
        public byte? DocType { get; set; }
        public int? Series { get; set; }
        public string DocStatusLov { get; set; }
        public string DocAprStatusLov { get; set; }
        public string UnitsId { get; set; }
        public string UnitsLovtype { get; set; }
        public string Purpose { get; set; }
        public byte? FamilyMember { get; set; }
        public int? SubId { get; set; }
        public string SubName { get; set; }
        public string Notes { get; set; }
        public bool? FlgMedical { get; set; }
        public string MedicalMode { get; set; }
        public bool? FlgPaid { get; set; }
        public string DestPh { get; set; }
        public string DestAddress { get; set; }
        public bool? FlgVisa { get; set; }
        public string TicketType { get; set; }
        public decimal? Compensation { get; set; }
        public string DeductId { get; set; }
        public decimal? DeductAmnt { get; set; }
        public string PendingDedId { get; set; }
        public decimal? PendingDedAmnt { get; set; }
        public decimal? DeductedAmnt { get; set; }
        public int? DeductedUnit { get; set; }
        public decimal? RembAmnt { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public decimal? Units { get; set; }
        public decimal? AttendanceId { get; set; }
        public string Remarks { get; set; }
        public DateTime? Adldate { get; set; }
        public bool? FlgOfficial { get; set; }
        public string LeavesType { get; set; }

        public virtual MstEmployee Emp { get; set; }
        public virtual MstLeaveType LeaveTypeNavigation { get; set; }
        public virtual ICollection<TrnsLeaveRequestHistory> TrnsLeaveRequestHistories { get; set; }
    }
}
