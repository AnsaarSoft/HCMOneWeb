using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstJobDesignation
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int? MinExperiance { get; set; }
        public string ParentDesignation { get; set; }
        public string JobPosition { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }
    }
}
