using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsSchoolPensionRequestDetail
    {
        public int Id { get; set; }
        public int? SchoolPensionRequestId { get; set; }
        public string ChildName { get; set; }
        public string SchoolName { get; set; }
        public string Grade { get; set; }
        public int? Amount { get; set; }

        public virtual TrnsSchoolPensionRequest SchoolPensionRequest { get; set; }
    }
}
