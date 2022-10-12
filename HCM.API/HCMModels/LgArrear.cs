using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class LgArrear
    {
        public int Id { get; set; }
        public int? MasterId { get; set; }
        public string FieldName { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public DateTime? LineTimeStamp { get; set; }
        public string Userid { get; set; }
    }
}
