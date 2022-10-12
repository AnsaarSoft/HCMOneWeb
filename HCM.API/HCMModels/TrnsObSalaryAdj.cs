using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsObSalaryAdj
    {
        public int Id { get; set; }
        public int? EmpId { get; set; }
        public string Description { get; set; }
        public decimal? Amount { get; set; }
        public bool? FlgActive { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int CalId { get; set; }
        public string CalCode { get; set; }
    }
}
