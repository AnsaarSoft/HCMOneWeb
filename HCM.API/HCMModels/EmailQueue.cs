using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class EmailQueue
    {
        public int Id { get; set; }
        public short? PriorityId { get; set; }
        public string FromEmail { get; set; }
        public string FromName { get; set; }
        public string ToEmail { get; set; }
        public string ToName { get; set; }
        public string ReplyTo { get; set; }
        public string ReplyToName { get; set; }
        public string Cc { get; set; }
        public string Bcc { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string AttachmentFilePath { get; set; }
        public string AttachmentFileName { get; set; }
        public int? AttachedDownloadId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? DontSendBeforeDate { get; set; }
        public short? SentTries { get; set; }
        public DateTime? SentOnUtc { get; set; }
        public int? EmailAccountId { get; set; }
        public int? TemplateId { get; set; }

        public virtual EmailTemplate Template { get; set; }
    }
}
