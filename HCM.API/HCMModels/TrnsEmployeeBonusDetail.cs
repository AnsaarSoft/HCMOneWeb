using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsEmployeeBonusDetail
    {
        public int Id { get; set; }
        public int? Fkid { get; set; }
        public int? EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public decimal? BasicSalary { get; set; }
        public decimal? GrossSalary { get; set; }
        public decimal? NetSalary { get; set; }
        public string SlabCode { get; set; }
        public string SalaryRange { get; set; }
        public decimal? Percentage { get; set; }
        public decimal? CalculatedAmount { get; set; }
        public bool? FlgActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        public virtual TrnsEmployeeBonu Fk { get; set; }
    }
}
