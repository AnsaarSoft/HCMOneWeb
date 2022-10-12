using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstAirTicketConfig
    {
        public int InternalId { get; set; }
        public int? ElementId { get; set; }
        public int? CountryId { get; set; }
        public int? GroupId { get; set; }
        public decimal? Amount { get; set; }
        public bool? FlgActive { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
