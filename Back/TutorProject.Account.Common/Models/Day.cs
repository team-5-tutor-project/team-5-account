﻿using System;
using System.Collections.Generic;

namespace TutorProject.Account.Common.Models
{
    public class Day
    {
        public Day()
        {
            for (int j = 0; j < 12; j++)
            {
                DaySchedule.Add(false);
            }
        }
        
        public Guid Id { get; init; }

        public List<bool> DaySchedule { get; set; } = new List<bool>();
    }
}