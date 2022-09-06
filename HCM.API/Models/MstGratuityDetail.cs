using System;
using System.Collections.Generic;

namespace HCM.API.Models
{
    public partial class MstGratuityDetail
    {
        public int Id { get; set; }
        public int? Fkid { get; set; }
        public string Description { get; set; }
        public decimal? FromPoints { get; set; }
        public decimal? ToPoints { get; set; }
        public decimal? DaysCount { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual MstGratuity Fk { get; set; }
    }
}
