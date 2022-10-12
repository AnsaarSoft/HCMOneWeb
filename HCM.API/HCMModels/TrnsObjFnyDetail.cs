using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsObjFnyDetail
    {
        public TrnsObjFnyDetail()
        {
            TrnsObjFnyProgresses = new HashSet<TrnsObjFnyProgress>();
        }

        public int Id { get; set; }
        public int? HeadId { get; set; }
        public string Subheading { get; set; }
        public string Weightage { get; set; }
        public string KpIndicator { get; set; }
        public string Timeline { get; set; }
        public string ApprovalStatus { get; set; }
        public int? DocNumber { get; set; }
        public string DocAprStatus { get; set; }
        public int? DocType { get; set; }
        public string DocStatus { get; set; }

        public virtual TrnsObjFnyHead Head { get; set; }
        public virtual ICollection<TrnsObjFnyProgress> TrnsObjFnyProgresses { get; set; }
    }
}
