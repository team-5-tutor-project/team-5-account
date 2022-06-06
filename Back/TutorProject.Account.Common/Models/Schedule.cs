using System;
using System.Collections.Generic;

namespace TutorProject.Account.Common.Models
{
    public class Schedule
    {
        public Guid Id { get; init; }
        
        public Tutor Tutor { get; init; }

        public List<Day> FreeTimeSchedule { get; init; } = new List<Day>();
    }
}