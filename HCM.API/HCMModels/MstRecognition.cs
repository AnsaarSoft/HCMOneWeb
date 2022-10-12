using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstRecognition
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool? StatusRecognition { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }
    }
}
