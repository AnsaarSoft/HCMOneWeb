using System;
using System.Collections.Generic;

namespace HCM.API.Models
{
    public partial class LogDepartment
    {
        public int Id { get; set; }
        public int SourceId { get; set; }
        public string Description { get; set; } = null!;
        public bool? FlgActive { get; set; }
        public string? LogUser { get; set; }
        public DateTime? LogTime { get; set; }
    }
}
