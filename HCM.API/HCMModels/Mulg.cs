using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class Mulg
    {
        public int Tid { get; set; }
        public int? Id { get; set; }
        public string UserId { get; set; }
        public string UserCode { get; set; }
        public string PassCode { get; set; }
        public int? Language { get; set; }
        public bool? FlgWebUser { get; set; }
        public bool? FlgActiveUser { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public int? Empid { get; set; }
        public bool? MultiLogin { get; set; }
        public DateTime? EventDate { get; set; }
        public string Uip { get; set; }
        public string Wun { get; set; }
    }
}
