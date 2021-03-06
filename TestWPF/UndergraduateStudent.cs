﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWPF
{
    class UndergraduateStudent : Person
    {
        public List<Course> courses = new List<Course>();
        public int studentId;

        public virtual void AddCourse(int num, string name, int gpa, int credits)
        {
            if (num >= 1000 && num <= 4999)
            {
                Course course = new Course(num, name, gpa, credits);
                courses.Add(course);
            }
            else { Console.WriteLine("invalid course number for UndergraduateStudent"); }
        }
    }
}
