using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class SendEmail
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Msg { get; set; }
        public string Status { get; set; }
        public DateTime? Date { get; set; }
    }
}
