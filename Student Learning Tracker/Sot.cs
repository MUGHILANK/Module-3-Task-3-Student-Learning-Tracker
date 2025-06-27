using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Student_Learning_Tracker
{
    public class StudentDetials
    {
        public int studentID { get; set; }
        public string studentName { get; set; }
        public double marks { get; set; }
        public double averageMarks { get; set; }
        
        public static List<StudentDetials> ListStudentDetails()
        {
            List<StudentDetials> studentList = new List<StudentDetials>();  

            string addWhileInput = "Y";
            while (addWhileInput == "Y")
            {
                Console.WriteLine("========== Student Details ==========");
                StudentDetials student = new StudentDetials();
                Console.Write("Enter Student ID: ");
                student.studentID = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Student Name: ");
                student.studentName = Console.ReadLine();
                Console.Write("Enter Student Marks for 500: ");
                student.marks = Convert.ToDouble(Console.ReadLine());

                studentList.Add(student);

                Console.WriteLine("Student details added successfully!");
                Console.Write("Do you want to add another student? (Y/N): ");
                addWhileInput = Console.ReadLine().ToUpper();
            }
            return studentList;

        }

        public static void DisplayStudentDetails(List<StudentDetials> studentList)
        {
            if (studentList.Count == 0)
            {
                Console.WriteLine("No student details available.");
                return;
            }
            Console.WriteLine("========== Student List ==========");
            foreach (var stu in studentList)
            {
                Console.WriteLine($"ID: {stu.studentID}, Name: {stu.studentName}, Marks: {stu.marks}");
            }
        }

        public static void CalculateAverageMarks(List<StudentDetials> studentList)
        {
            Console.WriteLine("========== Student Mark Details ==========");

            if (studentList.Count == 0)
            {
                Console.WriteLine("No student details available.");
                return;
            }

            foreach (var stu in studentList)
            {
                stu.averageMarks = stu.marks / 5;

                Console.WriteLine($"ID: {stu.studentID}, Name: {stu.studentName}, Total Marks: {stu.marks}, Average: {stu.averageMarks}%");
            }
        }

        public static void DisplayAverageMarks(List<StudentDetials> studentList)
        {
            if (studentList.Count == 0)
            {
                Console.WriteLine("No student details available.");
                return;
            }
            Console.WriteLine("========== Average Marks ==========");
            foreach (var stu in studentList)
            {
                Console.WriteLine($"ID: {stu.studentID}, Name: {stu.studentName}, Average Marks: {stu.averageMarks}%");
            }
        }

        public static void DisplayStudentDetailsById(List<StudentDetials> studentList, int studentId)
        {
            var student = studentList.FirstOrDefault(s => s.studentID == studentId);
            if (student != null)
            {
                Console.WriteLine($"ID: {student.studentID}, Name: {student.studentName}, Marks: {student.marks}");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        public static void AnalyzeTestScores(List<StudentDetials> studentList)
        {
            if (studentList == null || studentList.Count == 0)
            {
                Console.WriteLine("No student details available.");
                return;
            }

            
            double average = studentList.Average(s => s.marks);
            Console.WriteLine($"Average Marks: {average}");

           
            double topScore = studentList.Max(s => s.marks);
            var topScorers = studentList.Where(s => s.marks == topScore).ToList();
            Console.WriteLine("Top Scorer(s):");
            foreach (var stu in topScorers)
            {
                Console.WriteLine($"ID: {stu.studentID}, Name: {stu.studentName}, Marks: {stu.marks}");
            }


            double passingMarks = 250;
            var failedStudents = studentList.Where(s => s.marks < passingMarks).ToList();
            if (failedStudents.Count == 0)
            {
                Console.WriteLine("No failed students.");
            }
            else
            {
                Console.WriteLine("Failed Students:");
                foreach (var stu in failedStudents)
                {
                    Console.WriteLine($"ID: {stu.studentID}, Name: {stu.studentName}, Marks: {stu.marks}");
                }
            }
        }

        public static async Task SaveProgressToCsvAsync(List<StudentDetials> studentList, string filePath)
        {

            if (studentList == null || studentList.Count == 0)
            {
                Console.WriteLine("No student details available to save.");
                return;
            }

            var lines = new List<string>
            {
                "StudentID,StudentName,Marks,AverageMarks"
            };

            foreach (var stu in studentList)
            {
                lines.Add($"{stu.studentID},{stu.studentName},{stu.marks},{stu.averageMarks}");
            }

            await File.WriteAllLinesAsync(filePath, lines);
            Console.WriteLine($"Student progress saved to {filePath}");
        }
    }
}
