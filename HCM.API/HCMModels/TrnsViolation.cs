using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsViolation
    {
        public int Id { get; set; }
        public int? DocNum { get; set; }
        public DateTime? DocDate { get; set; }
        public byte? DocType { get; set; }
        public int? Series { get; set; }
        public string DocAprStatusLov { get; set; }
        public string DocStatusLov { get; set; }
        public string DocStatus { get; set; }
        public string DocAprStatus { get; set; }
        public int? InternalEmpId { get; set; }
        public string EmpName { get; set; }
        public string ViolationLevel { get; set; }
        public string PenaltyType { get; set; }
        public string DeductionType { get; set; }
        public decimal? DeductionUnit { get; set; }
        public int? DeductionPeriod { get; set; }
        public int? ManagerId { get; set; }
        public decimal? DeductionAmount { get; set; }
        public string Remarks { get; set; }
        public string Reason { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreateDt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdateDt { get; set; }

        public virtual MstEmployee InternalEmp { get; set; }
    }
}
