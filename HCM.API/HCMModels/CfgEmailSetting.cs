using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class CfgEmailSetting
    {
        public int Id { get; set; }
        public string FromAddress { get; set; }
        public string FromPassword { get; set; }
        public string Subject { get; set; }
        public string SmtpHost { get; set; }
        public string SmtpPort { get; set; }
        public string SmtpTimeout { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public bool? FlgActive { get; set; }
        public bool? Ssl { get; set; }
        public bool? Sae { get; set; }
    }
}
