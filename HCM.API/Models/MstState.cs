using System;
using System.Collections.Generic;

namespace HCM.API.Models
{
    public partial class MstState
    {
        public int Id { get; set; }
        public int? CountryId { get; set; }
        public string StateName { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual MstCountry Country { get; set; }
    }
}
