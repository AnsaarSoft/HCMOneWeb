using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstAppraisalTerm
    {
        public int TermId { get; set; }
        public int YearId { get; set; }
        public string TermDesc { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int TermNumber { get; set; }
    }
}
