﻿using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsVacancyStatus
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string InitiatedBy { get; set; }
        public string StatusVacancy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }
    }
}
