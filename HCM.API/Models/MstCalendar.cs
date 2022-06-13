﻿using System;
using System.Collections.Generic;

namespace HCM.API.Models
{
    public partial class MstCalendar
    {
        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? FlgActive { get; set; }
    }
}