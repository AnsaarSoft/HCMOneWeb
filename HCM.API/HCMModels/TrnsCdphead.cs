using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsCdphead
    {
        public TrnsCdphead()
        {
            TrnsCdpdetails = new HashSet<TrnsCdpdetail>();
        }

        public int Id { get; set; }
        public int? Empid { get; set; }
        public int? Year { get; set; }
        public string CommentsDevelopmentPlan { get; set; }
        public string CommentsCareerPath { get; set; }
        public string CommentsCareersPref { get; set; }
        public string CommentsComplinace { get; set; }
        public int? DocNumber { get; set; }
        public string DocAprStatus { get; set; }
        public int? DocType { get; set; }
        public string DocStatus { get; set; }

        public virtual MstEmployee Emp { get; set; }
        public virtual ICollection<TrnsCdpdetail> TrnsCdpdetails { get; set; }
    }
}
