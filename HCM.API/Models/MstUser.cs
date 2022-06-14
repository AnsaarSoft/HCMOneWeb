using System;
using System.Collections.Generic;

namespace HCM.API.Models
{
    public partial class MstUser
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string UserCode { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool? FlgPasswordRequest { get; set; }
        public bool? FlgActive { get; set; }
    }
}
