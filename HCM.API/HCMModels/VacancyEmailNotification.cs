using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class VacancyEmailNotification
    {
        public int Id { get; set; }
        public string Itemail { get; set; }
        public string AdminEmail { get; set; }
    }
}
