using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class UserAuthorization
    {
        public int Id { get; set; }
        public int? FkuserId { get; set; }
        public int? UserRights { get; set; }
        public int? FkmenuId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CappStamp { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UappStamp { get; set; }
        public int? MenuParent { get; set; }
        public string MenuName { get; set; }
        public string MenuLink { get; set; }
    }
}
