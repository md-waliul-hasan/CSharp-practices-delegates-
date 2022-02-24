using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;

namespace DelegateConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>
           {
               new Student{StudentId = 0, StudentName = "Waliul", StudentGrade = "A", IsGraduated = true},
               new Student{StudentId = 1, StudentName = "Hasan", StudentGrade = "A", IsGraduated = true},
               new Student{StudentId = 2, StudentName = "Rony", StudentGrade = "B", IsGraduated = true},
               new Student{StudentId = 3, StudentName = "Md", StudentGrade = "A", IsGraduated = true},
               new Student{StudentId = 4, StudentName = "Abc", StudentGrade = "D", IsGraduated = false},
               new Student{StudentId = 5, StudentName = "Def", StudentGrade = "C", IsGraduated = false},
           };

            var filteredGrades = GradesFilter(students, x => x == "A");
            var graduates = GraduateFilter(students, x => x == true);

            foreach (var student in graduates)
                Console.WriteLine($@"Name: {student.StudentName} Id: {student.StudentId}");

            foreach (var student in filteredGrades)
                Console.WriteLine($@"Name: {student.StudentName} Graduation Status: {student.IsGraduated}");

            Action1 ac = ShowNumbers;
            //ac(filteredList);
            ac(filteredGrades);
        }

        delegate void Action1(List<Student> list);

        private static void ShowNumbers(List<Student> list)
        {
            foreach (var student in list)
                Console.WriteLine($@"{student.StudentName}");
        }

        //Example of Func<T1,T2....T16, TResult>
        //func parameter referes a method/funciton. Here we passed it by lambda function
        public static List<Student> GradesFilter(List<Student> list, Func<string, bool> func)
        {
            List<Student> returnList = new List<Student>();

            foreach (var student in list)
            {
                if (func(student.StudentGrade))
                    returnList.Add(student);
            }
            return returnList;
        }

        public static List<Student> GraduateFilter(List<Student> list, Func<bool, bool> func)
        {
            List<Student> returnList = new List<Student>();

            foreach (var student in list)
            {
                if (func(student.IsGraduated))
                    returnList.Add(student);
            }
            return returnList;
        }
    }


    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentGrade { get; set; }
        public bool IsGraduated { get; set; }
    }

}
