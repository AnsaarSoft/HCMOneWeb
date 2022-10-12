using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsEmployeeTransferDetail
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public decimal? EmpId { get; set; }
        public string EmpCode { get; set; }
        public string EmpName { get; set; }
        public string ExistingLocation { get; set; }
        public string ToLocation { get; set; }
        public string CostCentre { get; set; }
        public string EmpCalendar { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string Dimension1 { get; set; }
        public string Dimension2 { get; set; }
        public string Dimension3 { get; set; }
        public string Dimension4 { get; set; }
        public string Dimension5 { get; set; }

        public virtual TrnsEmployeeTransfer Parent { get; set; }
    }
}
