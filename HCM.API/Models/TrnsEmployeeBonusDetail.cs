using System;
using System.Collections.Generic;

namespace HCM.API.Models
{
    public partial class TrnsEmployeeBonusDetail
    {
        public int Id { get; set; }
        public int? Fkid { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = null!;
        public decimal BasicSalary { get; set; }
        public decimal GrossSalary { get; set; }
        public decimal? NetSalary { get; set; }
        public string? SlabCode { get; set; }
        public string? SalaryRange { get; set; }
        public decimal? Percentage { get; set; }
        public decimal? CalculatedAmount { get; set; }
        public bool? FlgActive { get; set; }

        public virtual TrnsEmployeeBonu? Fk { get; set; }
    }
}
