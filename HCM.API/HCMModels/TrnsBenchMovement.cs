using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsBenchMovement
    {
        public TrnsBenchMovement()
        {
            TrnsBenchMovementDetails = new HashSet<TrnsBenchMovementDetail>();
        }

        public int Id { get; set; }
        public int? SenderEmpId { get; set; }
        public int? OnBenchEmpId { get; set; }
        public int? OnBoardEmpId { get; set; }
        public bool? FlgOnBench { get; set; }
        public bool? FlgOnBoard { get; set; }
        public DateTime? StartsFrom { get; set; }
        public DateTime? ToUntil { get; set; }
        public string LeaveType { get; set; }
        public int? DocNum { get; set; }
        public byte? DocType { get; set; }
        public string DocStatus { get; set; }
        public string DocAprStatus { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdatedBy { get; set; }
        public int? BoardNum { get; set; }
        public bool? FlgClosed { get; set; }

        public virtual MstEmployee SenderEmp { get; set; }
        public virtual ICollection<TrnsBenchMovementDetail> TrnsBenchMovementDetails { get; set; }
    }
}
