using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsEmployeeExitInterviewAttach
    {
        public int Id { get; set; }
        public int? ExitInterviewId { get; set; }
        public string DocName { get; set; }
        public string DocContent { get; set; }
        public string Extension { get; set; }
        public bool? FlgActive { get; set; }
        public bool? IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual TrnsEmployeeExitInterview ExitInterview { get; set; }
    }
}
