using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MenuHead
    {
        public int Id { get; set; }
        public int? MenuId { get; set; }
        public string MenuName { get; set; }
        public int? ParentId { get; set; }
        public string Navigation { get; set; }
        public int? SortOrder { get; set; }
    }
}
