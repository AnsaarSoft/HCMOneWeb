using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsCompetencyProfile
    {
        public TrnsCompetencyProfile()
        {
            TrnsCompetencyProfileDetails = new HashSet<TrnsCompetencyProfileDetail>();
        }

        public int Id { get; set; }
        public byte? DocType { get; set; }
        public int? Series { get; set; }
        public int? DocNum { get; set; }
        public DateTime? DocDate { get; set; }
        public int? EmpId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public string Branch { get; set; }
        public string Grade { get; set; }
        public bool? EmpStatus { get; set; }
        public string DocStatusId { get; set; }
        public string DocStatusLov { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }

        public virtual ICollection<TrnsCompetencyProfileDetail> TrnsCompetencyProfileDetails { get; set; }
    }
}
