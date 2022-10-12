using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstInstitute
    {
        public MstInstitute()
        {
            MstEmployeeEducations = new HashSet<MstEmployeeEducation>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string County { get; set; }
        public int? WorldRank { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }
        public int? CountryId { get; set; }
        public int? CityId { get; set; }
        public bool? FlgActive { get; set; }

        public virtual MstCity City { get; set; }
        public virtual MstCountry Country { get; set; }
        public virtual ICollection<MstEmployeeEducation> MstEmployeeEducations { get; set; }
    }
}
