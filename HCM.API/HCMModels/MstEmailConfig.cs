﻿using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstEmailConfig
    {
        public int Id { get; set; }
        public string Smtpserver { get; set; }
        public int? Smtport { get; set; }
        public string FromEmail { get; set; }
        public string Password { get; set; }
        public string TestEmail { get; set; }
        public bool? Ssl { get; set; }
    }
}
