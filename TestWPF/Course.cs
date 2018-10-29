﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWPF
{
    class Course
    {
        public Course(int num, string name, int gpa, int credits )
        {
            this.courseName = name;
            this.courseNumber = num;
            this.gpa = gpa;
            this.credits = credits;
        }
        private int courseNumber;
        private string courseName;
        private int gpa;
        private int credits;
        
        public int CourseNumber { get { return courseNumber; } }
        public string CourseName { get { return courseName; } }
        public int Gpa { get { return gpa; } }
        public int Credits { get { return credits; } }
    }
}
