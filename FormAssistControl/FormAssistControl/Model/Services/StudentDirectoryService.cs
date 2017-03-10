using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormAssistControl.Model.Entities;
using FormsAssistControl;

namespace FormAssistControl.Model.Services
{
    public class StudentDirectoryService
    {
        public static StudentDirectory LoadStudentDirectory()
        {
            DatabaseManager dbManager = new DatabaseManager();
            ObservableCollection<Student> students = 
                new ObservableCollection<Student>(dbManager.GetAllItems<Student>());
            StudentDirectory studentDirectory = new StudentDirectory();

            if (students.Any())
            {
                studentDirectory.Students = students;
                return studentDirectory;
            }

            students = new ObservableCollection<Student>();

            string[] names = { "José Luis", "Miguel Ángel", "José Francisco", "Jesús Antonio",
                                "Sofía", "Camila", "Valentina", "Isabella", "Ximena"};
            string[] lastNames = { "Hernández", "García", "Martínez", "López", "González" };

            Random rdn = new Random(DateTime.Now.Millisecond);

            students = new ObservableCollection<Student>();

            for (int i = 0; i < 20; i++)
            {
                Student student = new Student();
                student.Name = names[rdn.Next(0, 8)];
                student.LastName = $"{lastNames[rdn.Next(0, 5)]} {lastNames[rdn.Next(0, 5)]}";
                string group = rdn.Next(456, 458).ToString();
                student.Group = group;
                student.StudentNumber = rdn.Next(12384748, 32384748).ToString();
                student.Key = student.StudentNumber;
                student.Average = rdn.Next(100, 1000) / 10;

                students.Add(student);
                dbManager.SaveValue<Student>(student);
            }
            studentDirectory.Students = students;
            return studentDirectory;
        }
    }
}
