﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagerV2.Entity
{
    internal class Student
    {
        public String Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Yob { get; set; }
        public double Gpa { get; set; }
        public override string ToString() => $"Student: {Id} | {Name} | {Email} | {Yob} | {Gpa}";

    }
}
