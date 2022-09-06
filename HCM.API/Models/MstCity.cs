using System;
using System.Collections.Generic;

namespace HCM.API.Models
{
    public partial class MstCity
    {
        public int Id { get; set; }
        public string CityCode { get; set; }
        public string CityName { get; set; }
        public int? CountryId { get; set; }

        public virtual MstCountry Country { get; set; }
    }
}
