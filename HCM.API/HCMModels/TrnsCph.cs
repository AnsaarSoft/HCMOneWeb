using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsCph
    {
        public int Id { get; set; }
        public int ElementId { get; set; }
        public int VacancyNo { get; set; }
        public decimal Amount { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        public virtual MstCphelement Element { get; set; }
    }
}
