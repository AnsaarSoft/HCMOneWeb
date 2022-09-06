using System;
using System.Collections.Generic;

namespace HCM.API.Models
{
    public partial class MstUser
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string UserCode { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool? FlgPasswordRequest { get; set; }
        public bool? FlgActive { get; set; }
    }
}
