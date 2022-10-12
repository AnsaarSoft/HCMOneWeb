using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstCity
    {
        public MstCity()
        {
            MstInstitutes = new HashSet<MstInstitute>();
        }

        public int Id { get; set; }
        public string CityCode { get; set; }
        public string CityName { get; set; }
        public int? CountryId { get; set; }

        public virtual MstCountry Country { get; set; }
        public virtual ICollection<MstInstitute> MstInstitutes { get; set; }
    }
}
