using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstDetailTraningBudget
    {
        public int Id { get; set; }
        public string CategoryCode { get; set; }
        public string CategoryDeacription { get; set; }
        public string Location { get; set; }
        public string Gender { get; set; }
        public int? Participants { get; set; }
        public int? Days { get; set; }
        public decimal? TravellingFare { get; set; }
        public decimal? TravellingTotal { get; set; }
        public decimal? Accomodation { get; set; }
        public decimal? AccomodationTotal { get; set; }
        public decimal? TaDaPerDay { get; set; }
        public decimal? TaDaTotal { get; set; }
        public decimal? LunchPerDay { get; set; }
        public decimal? LunchTotal { get; set; }
        public decimal? LocalTransPerDay { get; set; }
        public decimal? TransportTotal { get; set; }
        public decimal? GrandTotal { get; set; }
        public decimal? Total { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int? VenueId { get; set; }
        public string VenueDescription { get; set; }
        public int? PlanId { get; set; }
        public string PlanDescription { get; set; }
    }
}
