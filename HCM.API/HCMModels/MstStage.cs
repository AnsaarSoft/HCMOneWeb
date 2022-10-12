using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstStage
    {
        public MstStage()
        {
            DocumentTemplateDetails = new HashSet<DocumentTemplateDetail>();
            MstStageDetails = new HashSet<MstStageDetail>();
        }

        public int Id { get; set; }
        public string StageName { get; set; }
        public string StageDescription { get; set; }
        public int? NumberOfApprovals { get; set; }
        public int? NumberOfRejectins { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool? FlgActive { get; set; }
        public int? LocationId { get; set; }

        public virtual MstLocation Location { get; set; }
        public virtual ICollection<DocumentTemplateDetail> DocumentTemplateDetails { get; set; }
        public virtual ICollection<MstStageDetail> MstStageDetails { get; set; }
    }
}
