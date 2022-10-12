using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstDocumentNumberSeries
    {
        public int Id { get; set; }
        public int? FkformCode { get; set; }
        public string FormName { get; set; }
        public string Prefix { get; set; }
        public int? StartNo { get; set; }
        public bool? FlgActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
