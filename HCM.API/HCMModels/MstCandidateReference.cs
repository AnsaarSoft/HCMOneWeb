using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstCandidateReference
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string Organization { get; set; }
        public string Designation { get; set; }
        public string RelationshipWithCandidate { get; set; }
        public string RemarksFromReference { get; set; }
        public int CandidateId { get; set; }
        public string Email { get; set; }

        public virtual MstCandidate Candidate { get; set; }
    }
}
