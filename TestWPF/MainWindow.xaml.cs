using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestWPF
{
    
    public partial class MainWindow : Window
    {
        int currentStudent = 0;
        int currentCourse = 0;
        int studentTypeIndex = 0;
        List<Person> people = new List<Person>();

        public MainWindow()
        {
            InitializeComponent();
        }    

        private void AddStudentButton_Click(object sender, RoutedEventArgs e)
        {
            ListBoxItem studentListBoxItem = new ListBoxItem();
            studentListBoxItem.Content = LastNameTextBox.Text + " " + FirstNameTextBox.Text;
            StudentsListBox.Items.Add(studentListBoxItem);
            CreatePerson();            
            //add either grad or undergrad to list of type person
        }    
        private void AddCourseButton_Click(object sender, RoutedEventArgs e)
        {

            int number, gpa, credits;
            int.TryParse(CourseNumberTextBox.Text, out number);
            int.TryParse(GPATextBox.Text, out gpa);
            int.TryParse(CreditHoursTextBox.Text, out credits);
            if(people.Count == 0)
            {
            //if fixes exception
                return;
            }
            if (people[currentStudent].GetType().Name == "GraduateStudent")
            {                
                (people[currentStudent] as GraduateStudent).AddCourse(number, CourseNameTextBox.Text, gpa, credits);
            }
            else if (people[currentStudent].GetType().Name == "UndergraduateStudent")
            {
                (people[currentStudent] as UndergraduateStudent).AddCourse(number, CourseNameTextBox.Text, gpa, credits);
            }
            //ensure student is selected, add the course info to the selected students courses

            PopulateCourseList();
            TotalGPADisplay();
        }
        private void StudentsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentStudent = this.StudentsListBox.SelectedIndex;
            StudentSelected();
            TotalGPADisplay();
        }
        private void CoursessListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentCourse = this.CoursessListBox.SelectedIndex;
            PopulateCourseFields();
            TotalGPADisplay();
        }       
        private void StudentTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            studentTypeIndex = StudentTypeComboBox.SelectedIndex;
        }
        private void CreatePerson() {
            if(studentTypeIndex == 0)
            {
                UndergraduateStudent student = new UndergraduateStudent();
                int age;
                int.TryParse(AgeTextBox.Text, out age);
                student.Age = age;
                student.FirstName = FirstNameTextBox.Text;
                student.LastName = LastNameTextBox.Text;
                int id;
                int.TryParse(StudentIDTextBox.Text, out id);
                student.studentId = id;
                student.Gender = GenderCombo.SelectedIndex;

                people.Add(student);
            }
            else
            {
                GraduateStudent student = new GraduateStudent();
                int age;
                int.TryParse(AgeTextBox.Text, out age);
                student.Age = age;
                student.FirstName = FirstNameTextBox.Text;
                student.LastName = LastNameTextBox.Text;
                int id;
                int.TryParse(StudentIDTextBox.Text, out id);
                student.studentId = id;
                student.Gender = GenderCombo.SelectedIndex;

                people.Add(student);
            }
        }        
        private void PopulateCourseFields()
        {
            if (people[currentStudent].GetType().Name == "GraduateStudent")
            {
                CourseNameTextBox.Text = (people[currentStudent] as GraduateStudent).courses[currentCourse].CourseName;
                CourseNumberTextBox.Text = (people[currentStudent] as GraduateStudent).courses[currentCourse].CourseNumber.ToString();
                GPATextBox.Text = (people[currentStudent] as GraduateStudent).courses[currentCourse].Gpa.ToString();
                CreditHoursTextBox.Text = (people[currentStudent] as GraduateStudent).courses[currentCourse].Credits.ToString();
            }
            else if (people[currentStudent].GetType().Name == "UndergraduateStudent")
            {
                CourseNameTextBox.Text = (people[currentStudent] as UndergraduateStudent).courses[currentCourse].CourseName;
                CourseNumberTextBox.Text = (people[currentStudent] as UndergraduateStudent).courses[currentCourse].CourseNumber.ToString();
                GPATextBox.Text = (people[currentStudent] as UndergraduateStudent).courses[currentCourse].Gpa.ToString();
                CreditHoursTextBox.Text = (people[currentStudent] as UndergraduateStudent).courses[currentCourse].Credits.ToString();
            }
        }
        private void PopulateCourseList()
        {
            if (people[currentStudent].GetType().Name == "GraduateStudent")
            {
                (people[currentStudent] as GraduateStudent).courses.ForEach(course =>
                {
                    ListBoxItem courseListBoxItem = new ListBoxItem();
                    courseListBoxItem.Content = course.CourseName;
                    CoursessListBox.Items.Add(courseListBoxItem);
                });
            }
            else if (people[currentStudent].GetType().Name == "UndergraduateStudent")
            {
                (people[currentStudent] as UndergraduateStudent).courses.ForEach(course =>
                {
                    ListBoxItem courseListBoxItem = new ListBoxItem();
                    courseListBoxItem.Content = course.CourseName;
                    CoursessListBox.Items.Add(courseListBoxItem);
                    Console.WriteLine(CoursessListBox.ToString());
                });                             
            }
            else { Console.WriteLine("how did we get here?"); }
        }
        private void PopulateStudentFields()
        {
            if (this.currentStudent == -1) { return; }
            if (people[currentStudent].GetType().Name == "GraduateStudent")
            {
                StudentTypeComboBox.SelectedIndex = 1;
                GenderCombo.SelectedIndex = 1;
                StudentIDTextBox.Text = (people[this.currentStudent] as GraduateStudent).studentId.ToString();
                if ((people[currentStudent] as GraduateStudent).Gender == 0)
                {
                    GenderCombo.SelectedIndex = 0;
                }
                else if ((people[currentStudent] as GraduateStudent).Gender == 1)
                {
                    GenderCombo.SelectedIndex = 1;
                }
                else
                {
                    GenderCombo.SelectedIndex = 2;
                }
            }
            if (people[currentStudent].GetType().Name == "UndergraduateStudent")
            {
                StudentTypeComboBox.SelectedIndex = 0;
                GenderCombo.SelectedItem = 0;
                StudentIDTextBox.Text = (people[currentStudent] as UndergraduateStudent).studentId.ToString();
                if ((people[currentStudent] as UndergraduateStudent).Gender == 0)
                {
                    GenderCombo.SelectedIndex = 0;
                }
                else if ((people[currentStudent] as UndergraduateStudent).Gender == 1)
                {
                    GenderCombo.SelectedIndex = 1;
                }
                else
                {
                    GenderCombo.SelectedIndex = 2;
                }
            }
            FirstNameTextBox.Text = people[currentStudent].FirstName;
            LastNameTextBox.Text = people[currentStudent].LastName;
            AgeTextBox.Text = people[currentStudent].Age.ToString();
        }
        private void TotalGPADisplay()
        {
            int totalCredits = 0;
            int totalpoints = 0;
            if (people[currentStudent].GetType().Name == "GraduateStudent")
            {
                (people[currentStudent] as GraduateStudent).courses.ForEach(
                (Course course) =>
                {
                    totalCredits += course.Credits; totalpoints += course.Gpa;
                });
            }
            if (people[currentStudent].GetType().Name == "UndergraduateStudent")
            {
                (people[currentStudent] as UndergraduateStudent).courses.ForEach(
               (Course course) =>
               {
                   totalCredits += course.Credits; totalpoints += course.Gpa;
               });
            }
            TotalGPATextBox.Text = ((totalCredits * (float)totalpoints / totalCredits).ToString());
        }
        private void StudentSelected(){PopulateStudentFields();PopulateCourseList();}        
    }
}
