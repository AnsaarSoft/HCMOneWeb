using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstUsersAuth
    {
        public int Id { get; set; }
        public int? FunctionId { get; set; }
        public int? UserId { get; set; }
        public string UserRights { get; set; }

        public virtual MstUserFunction Function { get; set; }
    }
}
