using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstAppraisalGrade
    {
        public int Id { get; set; }
        public int YearId { get; set; }
        public decimal Min { get; set; }
        public decimal Max { get; set; }
        public string Grade { get; set; }
    }
}
