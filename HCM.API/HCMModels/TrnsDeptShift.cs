using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsDeptShift
    {
        public TrnsDeptShift()
        {
            TrnsDeptShiftDetails = new HashSet<TrnsDeptShiftDetail>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public string Ref { get; set; }
        public DateTime? EffectiveFrom { get; set; }
        public DateTime? EffectiveTo { get; set; }
        public string ShiftFor { get; set; }
        public int? ShiftForId { get; set; }
        public bool? FlgActive { get; set; }
        public string ApprovalStatus { get; set; }
        public string Status { get; set; }
        public DateTime? CreateDt { get; set; }
        public DateTime? UpdateDt { get; set; }
        public string CreateBy { get; set; }
        public string UpdateBy { get; set; }
        public string DocStatus { get; set; }
        public string DocStatusLov { get; set; }
        public string DocAprStatus { get; set; }
        public string DocAprStatusLov { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? DocNum { get; set; }
        public byte? DocType { get; set; }
        public int? DepartmentId { get; set; }

        public virtual ICollection<TrnsDeptShiftDetail> TrnsDeptShiftDetails { get; set; }
    }
}
