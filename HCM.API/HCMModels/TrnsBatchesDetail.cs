using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsBatchesDetail
    {
        public int Id { get; set; }
        public int? BatchesId { get; set; }
        public int? EmployeeId { get; set; }
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public string ValueType { get; set; }
        public decimal? EmplCont { get; set; }
        public decimal? EmplrCont { get; set; }
        public string Remarks { get; set; }
        public decimal? Value { get; set; }
        public bool? FlgActive { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }

        public virtual TrnsBatch Batches { get; set; }
        public virtual MstEmployee Employee { get; set; }
    }
}
