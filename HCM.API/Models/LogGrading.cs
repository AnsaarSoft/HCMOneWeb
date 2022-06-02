using System;
using System.Collections.Generic;

namespace HCM.API.Models
{
    public partial class LogGrading
    {
        public int Id { get; set; }
        public int SourceId { get; set; }
        public string? Description { get; set; }
        public decimal? MinSalary { get; set; }
        public decimal? MaxSalary { get; set; }
        public bool? FlgActive { get; set; }
        public string? LogUser { get; set; }
        public DateTime? LogTime { get; set; }
    }
}
