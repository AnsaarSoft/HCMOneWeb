using System;
using System.Collections.Generic;

namespace HCM.API.Models
{
    public partial class MstLoan
    {
        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool? FlgActive { get; set; }
        public bool? FlgDefault { get; set; }
    }
}
