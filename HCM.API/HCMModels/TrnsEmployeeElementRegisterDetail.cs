using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsEmployeeElementRegisterDetail
    {
        public int Id { get; set; }
        public int? EeregisterId { get; set; }
        public int? ElementId { get; set; }
        public decimal? Value { get; set; }
        public decimal? Amount { get; set; }
        public bool? FlgActive { get; set; }
        public decimal? RetroPayAmount { get; set; }
        public bool? FlgRetroActive { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }

        public virtual TrnsEmployeeElementRegister Eeregister { get; set; }
        public virtual MstElement Element { get; set; }
    }
}
