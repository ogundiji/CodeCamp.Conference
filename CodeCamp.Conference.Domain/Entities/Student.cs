﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCamp.Conference.Domain.Entities
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }

        public StudentAddress Address { get; set; }
    }
}
