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
    /// <summary>
    /// MainWindow.xaml 
    /// </summary>
    public partial class MainWindow : Window
    {
        int currentStudent = 0;
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
            createPerson();            
            //add either grad or undergrad to list of type person
        }

        private void AddCourseButton_Click(object sender, RoutedEventArgs e)
        {
            //ensure student is selected, add the course info to the selected students courses
        }

        private void StudentsListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            currentStudent = this.StudentsListBox.SelectedIndex;
            studentSelected();
        }
        private void studentSelected()
        {
            // having trouble changing combobox selection programatically
            //          TODO:
            //               gender comboBob && student type comboBox
            if (people[this.currentStudent].GetType().Name=="GraduateStudent")
            {
                //StudentTypeComboBox.SelectedItem = StudentTypeComboBox.Items.OfType<ComboBoxItem>().FirstOrDefault(comboBoxItem => (string)comboBoxItem.Content == "GraduateStudent");
                StudentIDTextBox.Text = (people[this.currentStudent] as GraduateStudent).studentId.ToString();
            }
            if (people[this.currentStudent].GetType().Name == "UndergraduateStudent")
            {
                //StudentTypeComboBox.SelectedItem = StudentTypeComboBox.Items.OfType<ComboBoxItem>().FirstOrDefault(comboBoxItem => (string)comboBoxItem.Content == "UnderGraduateStudent");
                StudentIDTextBox.Text = (people[this.currentStudent] as UndergraduateStudent).studentId.ToString();
            }
            FirstNameTextBox.Text = people[this.currentStudent].FirstName;
            LastNameTextBox.Text = people[this.currentStudent].LastName;
            AgeTextBox.Text = people[this.currentStudent].Age.ToString();
        }
        private void createPerson() {
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
                people.Add(student);
            }

            //people.Add(person);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            studentTypeIndex = StudentTypeComboBox.SelectedIndex;
        }
    }
}
