using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstCoachingDoc
    {
        public int Id { get; set; }
        public int? EmpId { get; set; }
        public int? CoachId { get; set; }
        public int? DocNum { get; set; }
        public DateTime? DocDate { get; set; }
        public string Activities { get; set; }
        public string ActionSteps { get; set; }
        public string MileStones { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
