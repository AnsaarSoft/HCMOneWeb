using System;
using System.Collections.Generic;

namespace HCM.API.Models
{
    public partial class PasswordReset
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string UserCode { get; set; } = null!;
        public string EncryptKey { get; set; } = null!;
        public bool FlgActive { get; set; }
    }
}
