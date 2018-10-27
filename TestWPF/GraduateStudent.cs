using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWPF
{
    class GraduateStudent : UndergraduateStudent
    {
        public new List<Course> courses = new List<Course>();
        public new int studentId;

        override public void AddCourse(int num, string name, int gpa, int credits)
        {
            if (num >= 5000 && num <= 9999)
            { 
                Course course = new Course(num, name, gpa, credits);
                courses.Add(course);
            }
            else { Console.WriteLine("invalid course number for GraduateStudent"); }
        }
    }
}
