using System;
using System.Collections.Generic;

namespace TutorProject.Account.Common.Models
{
    public class Schedule
    {
        public Schedule()
        {
            FreeTimeSchedule = new List<Day>();
            for (int i = 0; i < 7; i++)
            {
                FreeTimeSchedule.Add(new Day());
                
            } 
        }
        public Guid Id { get; init; }
        
        public Tutor Tutor { get; init; }

        public List<Day> FreeTimeSchedule { get; init; }
    }
}