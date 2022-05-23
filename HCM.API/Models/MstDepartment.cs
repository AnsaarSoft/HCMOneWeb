using System;
using System.Collections.Generic;

namespace HCM.API.Models
{
    public partial class MstDepartment
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public bool? FlgActive { get; set; }
    }
}
