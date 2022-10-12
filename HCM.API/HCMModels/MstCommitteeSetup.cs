using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstCommitteeSetup
    {
        public MstCommitteeSetup()
        {
            MstEmployeeCommittees = new HashSet<MstEmployeeCommittee>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string CreatedBy { get; set; }
        public bool? FlgActive { get; set; }
        public string UserId { get; set; }

        public virtual ICollection<MstEmployeeCommittee> MstEmployeeCommittees { get; set; }
    }
}
