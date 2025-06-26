using Student_Learning_Tracker;
using System.Reflection;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Student_Learning_Tracker
{
    class Program
    {
        static async Task Main(string[] args)
        {
            List<StudentDetials> studentList = new List<StudentDetials>();
            List<string> quizQuestions = new List<string>();

            string addWhileInput = "Y";
            while (addWhileInput == "Y")
            {
                Console.WriteLine("========== Student Learning Tracker ==========");
                Console.WriteLine("1. Add Student Details");
                Console.WriteLine("2. Display Student Details");
                Console.WriteLine("3. Calculate Average Marks");
                Console.WriteLine("4. Analyze Test Scores");
                
                Console.WriteLine("7. Exit");
                Console.Write("Enter your choice (1-7): ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        var newStudents = StudentDetials.ListStudentDetails();
                        studentList.AddRange(newStudents);
                        break;
                    case 2:
                        StudentDetials.DisplayStudentDetails(studentList);
                        break;
                    case 3:
                        StudentDetials.CalculateAverageMarks(studentList);
                        break;
                    case 4:
                        StudentDetials.AnalyzeTestScores(studentList);
                        break;
                    
                    case 7:
                        Console.WriteLine("Exiting the program.");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}










































//case 5:
//    Console.Write("Enter quiz questions file path: ");
//    string questionsPath = Console.ReadLine();
//    quizQuestions = await QuizManager.LoadQuestionsAsync(questionsPath);
//    Console.WriteLine($"Loaded {quizQuestions.Count} questions.");
//    break;
//case 6:
//    Console.Write("Enter results file path: ");
//    string resultsPath = Console.ReadLine();
//    Console.Write("Enter quiz result (e.g., StudentID: 1, Score: 80): ");
//    string result = Console.ReadLine();
//    QuizManager.SubmitQuizResultsInBackground(resultsPath, result);
//    break;


//    Console.WriteLine("5. Load Quiz Questions (Async)");
//    Console.WriteLine("6. Submit Quiz Results (Background)");