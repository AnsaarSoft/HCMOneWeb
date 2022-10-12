using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsMedical
    {
        public int Id { get; set; }
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime MDate { get; set; }
        public string Relation { get; set; }
        public string Consultation { get; set; }
        public string Medicine { get; set; }
        public decimal Amount { get; set; }
    }
}
