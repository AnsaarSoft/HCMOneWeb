using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstCandidateAttachment
    {
        public int Id { get; set; }
        public int? AttachmentId { get; set; }
        public int? CandidateId { get; set; }
        public string AttachmentPath { get; set; }
    }
}
