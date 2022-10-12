using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstTravelExpense
    {
        public int Id { get; set; }
        public int? DesignationId { get; set; }
        public decimal? OutBack { get; set; }
        public decimal? FareKm { get; set; }
        public decimal? NightStay { get; set; }
        public decimal? DailyAllowanceWd { get; set; }
        public decimal? MedicalAllowance { get; set; }
        public decimal? EntertainmentAllwnc { get; set; }
        public decimal? MobileAllwnc { get; set; }
        public decimal? MotorBikeAllwnc { get; set; }
        public decimal? CarAllwnc { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual MstDesignation Designation { get; set; }
    }
}
