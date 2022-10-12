using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstEmployeeReference
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string Organization { get; set; }
        public string Designation { get; set; }
        public string RelationshipWithCandidate { get; set; }
        public string RemarksFromReference { get; set; }
        public int EmployeeId { get; set; }

        public virtual MstEmployee Employee { get; set; }
    }
}
