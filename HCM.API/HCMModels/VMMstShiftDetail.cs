namespace HCM.API.Models
{
    public class VMMstShiftDetail
    {
        public int Id { get; set; }
        public int? Fkid { get; set; }
        public string Day { get; set; } = null!;       
        public bool? FlgOutOverlap { get; set; }       
        public bool? FlgExpectedIn { get; set; }
        public bool? FlgExpectedOut { get; set; }
        public TimeSpan? TSStartTime { get; set; }
        public TimeSpan? TSEndTime { get; set; }
        public TimeSpan? TSDuration { get; set; }
        public TimeSpan? TSBufferStartTime { get; set; }
        public TimeSpan? TSBufferEndTime { get; set; }
        public TimeSpan? TSGraceStartTime { get; set; }
        public TimeSpan? TSGraceEndTime { get; set; }
        public TimeSpan? TSBreakTime { get; set; }
    }
}
