using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsPerPieceTransactionDetail
    {
        public int Id { get; set; }
        public int? FkId { get; set; }
        public string EmpCode { get; set; }
        public string EmpName { get; set; }
        public string DepartmentName { get; set; }
        public string DesignationName { get; set; }
        public string PayrollPeriod { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string SubItemName { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public bool? Rework { get; set; }
        public string StattionCode { get; set; }
        public string StattionName { get; set; }
        public decimal? PrdQty { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UserId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdatedBy { get; set; }

        public virtual TrnsPerPieceTransaction Fk { get; set; }
    }
}
