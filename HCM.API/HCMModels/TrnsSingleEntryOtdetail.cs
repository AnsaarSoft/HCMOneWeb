﻿using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsSingleEntryOtdetail
    {
        public int Id { get; set; }
        public int? SingleEntryOtid { get; set; }
        public int? EmpId { get; set; }
        public string EmpName { get; set; }
        public int? OverTimeId { get; set; }
        public decimal? Hours { get; set; }
        public decimal? Amount { get; set; }
        public bool? FlgActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? AttendanceDate { get; set; }
        public string CalculatedOt { get; set; }
        public int? AttendanceId { get; set; }
        public string Remarks { get; set; }

        public virtual MstEmployee Emp { get; set; }
        public virtual MstOverTime OverTime { get; set; }
        public virtual TrnsSingleEntryOtrequest SingleEntryOt { get; set; }
    }
}