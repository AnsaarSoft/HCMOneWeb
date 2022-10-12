using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstEmployeeExperience
    {
        public int Id { get; set; }
        public int? EmpId { get; set; }
        public string CompanyName { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string Position { get; set; }
        public string Duties { get; set; }
        public string LastSalary { get; set; }
        public string Notes { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdateBy { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Department { get; set; }

        public virtual MstEmployee Emp { get; set; }
    }
}
