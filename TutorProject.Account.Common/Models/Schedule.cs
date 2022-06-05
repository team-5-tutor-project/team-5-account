using System;

namespace TutorProject.Account.Common.Models
{
    public class Schedule
    {
        public Guid ScheduleId { get; init; }
        
        public Tutor Tutor { get; init; }

        public bool[,] FreeTimeSchedule { get; init; } = new bool[7, 12];
    }
}