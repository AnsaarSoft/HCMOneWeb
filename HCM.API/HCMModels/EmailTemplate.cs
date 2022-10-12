using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class EmailTemplate
    {
        public EmailTemplate()
        {
            EmailQueues = new HashSet<EmailQueue>();
        }

        public int Id { get; set; }
        public short? EmailsType { get; set; }
        public string TemplateName { get; set; }
        public int? NotificationDays { get; set; }
        public string ToEmails { get; set; }
        public string Ccemails { get; set; }
        public string BccEmails { get; set; }
        public string Subject { get; set; }
        public string MailContent { get; set; }
        public bool? FlgActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual ICollection<EmailQueue> EmailQueues { get; set; }
    }
}
