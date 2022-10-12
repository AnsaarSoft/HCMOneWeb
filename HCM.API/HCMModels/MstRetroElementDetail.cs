using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstRetroElementDetail
    {
        public int Id { get; set; }
        public int? RetroId { get; set; }
        public int? ElementId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }

        public virtual MstElement Element { get; set; }
        public virtual MstRetroElementSet Retro { get; set; }
    }
}
