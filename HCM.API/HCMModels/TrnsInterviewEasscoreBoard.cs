using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsInterviewEasscoreBoard
    {
        public int Id { get; set; }
        public int? Ieasid { get; set; }
        public int? AssestmentId { get; set; }
        public decimal? AverageMarks { get; set; }
        public string Remarks { get; set; }

        public virtual MstAssestment Assestment { get; set; }
        public virtual TrnsInterviewEa Ieas { get; set; }
    }
}
