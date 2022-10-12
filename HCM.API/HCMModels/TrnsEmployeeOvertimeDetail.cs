using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsEmployeeOvertimeDetail
    {
        public int Id { get; set; }
        public int? EmpOvertimeId { get; set; }
        public int? OvertimeId { get; set; }
        public DateTime? Otdate { get; set; }
        public string FromTime { get; set; }
        public string ToTime { get; set; }
        public decimal? Othours { get; set; }
        public decimal? BasicSalary { get; set; }
        public string ValueType { get; set; }
        public decimal? Otvalue { get; set; }
        public decimal? Amount { get; set; }
        public bool? FlgActive { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }
        public int? DocNum { get; set; }
        public byte? DocType { get; set; }
        public string DocStatusLov { get; set; }
        public string DocAprStatus { get; set; }
        public string DocAprStatusLov { get; set; }
        public string DocStatus { get; set; }
        public int? ManagerId { get; set; }

        public virtual TrnsEmployeeOvertime EmpOvertime { get; set; }
        public virtual MstOverTime Overtime { get; set; }
    }
}
