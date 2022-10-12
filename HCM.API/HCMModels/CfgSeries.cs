using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class CfgSeries
    {
        public int Id { get; set; }
        public string SeriesName { get; set; }
        public byte? DocType { get; set; }
        public long? StartDocNum { get; set; }
        public long? CurrentDocNum { get; set; }
        public long? LastDocNum { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }
    }
}
