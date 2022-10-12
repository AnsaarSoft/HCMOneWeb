using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstAssestment
    {
        public MstAssestment()
        {
            MstAssestmentCriteria = new HashSet<MstAssestmentCriterion>();
            TrnsInterviewEasscoreBoards = new HashSet<TrnsInterviewEasscoreBoard>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Assestment { get; set; }
        public DateTime? CreateDt { get; set; }
        public string UserId { get; set; }
        public DateTime? UpdateDt { get; set; }
        public string UpdatedBy { get; set; }

        public virtual ICollection<MstAssestmentCriterion> MstAssestmentCriteria { get; set; }
        public virtual ICollection<TrnsInterviewEasscoreBoard> TrnsInterviewEasscoreBoards { get; set; }
    }
}
