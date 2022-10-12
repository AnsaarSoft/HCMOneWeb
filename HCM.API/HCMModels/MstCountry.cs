using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstCountry
    {
        public MstCountry()
        {
            MstCities = new HashSet<MstCity>();
            MstInstitutes = new HashSet<MstInstitute>();
            MstStates = new HashSet<MstState>();
        }

        public int Id { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual ICollection<MstCity> MstCities { get; set; }
        public virtual ICollection<MstInstitute> MstInstitutes { get; set; }
        public virtual ICollection<MstState> MstStates { get; set; }
    }
}
