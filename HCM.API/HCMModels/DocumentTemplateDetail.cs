using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class DocumentTemplateDetail
    {
        public int Id { get; set; }
        public int? DocumentHierarchyId { get; set; }
        public int? StageId { get; set; }

        public virtual DocumentTemplate DocumentHierarchy { get; set; }
        public virtual MstStage Stage { get; set; }
    }
}
