using System;
using System.Collections.Generic;

namespace HCM.API.Models
{
    public partial class MstDepartment
    {
        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public bool? FlgActive { get; set; }
    }
}
