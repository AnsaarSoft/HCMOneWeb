using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstPayBand
    {
        public int Id { get; set; }
        public string PayBandName { get; set; }
        public string Description { get; set; }
        public decimal? SalaryRangeFrom { get; set; }
        public decimal? SalaryRangeTo { get; set; }
        public int? MonthsinYear { get; set; }
        public string Gl { get; set; }
        public int? WeeksinYear { get; set; }
        public decimal? WeekDayRate { get; set; }
        public decimal? WeekendRate { get; set; }
        public decimal? WrkHrsinWeek { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
