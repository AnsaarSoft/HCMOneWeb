using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstPerformanceAssessmentCriterion
    {
        public int Id { get; set; }
        public short? Points { get; set; }
        public string Description { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }
    }
}
