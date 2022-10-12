using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsEmployeeHiring
    {
        public int Id { get; set; }
        public int? CandidateId { get; set; }
        public string ContractType { get; set; }
        public string ProbabtionPeriod { get; set; }
        public string OfferStatus { get; set; }
        public bool? EmpContractAccepted { get; set; }
        public int? ElementDetailId { get; set; }
        public string Empcode { get; set; }

        public virtual TrnsEmpElementHead ElementDetail { get; set; }
    }
}
