using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class PasswordReset
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string UserCode { get; set; }
        public string EncryptKey { get; set; }
        public bool FlgActive { get; set; }
    }
}
