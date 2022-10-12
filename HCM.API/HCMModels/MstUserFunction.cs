using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstUserFunction
    {
        public MstUserFunction()
        {
            MstUsersAuths = new HashSet<MstUsersAuth>();
        }

        public int Id { get; set; }
        public string FunctionName { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public string MenuId { get; set; }

        public virtual ICollection<MstUsersAuth> MstUsersAuths { get; set; }
    }
}
