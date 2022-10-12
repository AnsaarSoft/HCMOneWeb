using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstLove
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        public string Type { get; set; }
        public string Language { get; set; }
    }
}
