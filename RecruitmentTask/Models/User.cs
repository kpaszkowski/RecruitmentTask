﻿using System.Collections.Generic;

namespace RecruitmentTask.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Raport> Raports { get; set; }
    }
}