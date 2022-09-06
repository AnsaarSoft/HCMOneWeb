using System;
using System.Collections.Generic;

namespace HCM.API.Models
{
    public partial class MstCountry
    {
        public MstCountry()
        {
            MstCities = new HashSet<MstCity>();
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
        public virtual ICollection<MstState> MstStates { get; set; }
    }
}
