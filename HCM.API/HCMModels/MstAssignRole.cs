using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstAssignRole
    {
        public int Id { get; set; }
        public string Role { get; set; }
        public int? MenuId { get; set; }
        public string AuthorizationType { get; set; }
        public int? EmpId { get; set; }
    }
}
