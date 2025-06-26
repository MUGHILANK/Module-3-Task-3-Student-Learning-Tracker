//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Reflection;
//using System.Text;
//using System.Threading.Tasks;

//namespace Student_Learning_Tracker
//{
//    // Custom Attribute
//    [AttributeUsage(AttributeTargets.Method)]
//    public class TrackProgressAttribute : Attribute { }

//    // Generic Result Wrapper
//    public class Result<T>
//    {
//        public T Data { get; set; }
//        public string Message { get; set; }
//        public bool Success { get; set; }
//    }

//    // Student Class
//    public class Student
//    {
//        public int Id { get; set; }
//        public string Name { get; set; }
//        public List<QuizResult> QuizResults { get; set; } = new List<QuizResult>();

//        [TrackProgress]
//        public void TakeQuiz(List<Question> questions, Func<Question, string, bool> scoreFunc, IQuizService quizService)
//        {
//            int correct = 0;
//            foreach (var q in questions)
//            {
//                Console.WriteLine($"Q: {q.Text}");
//                string ans = Console.ReadLine();
//                if (scoreFunc(q, ans)) correct++;
//            }

//            double score = (double)correct / questions.Count * 100;
//            var result = new QuizResult { QuizName = questions[0].Subject, Score = score };
//            QuizResults.Add(result);
//            quizService.OnQuizCompleted(this, result);
//        }

//        public double AverageScore() => QuizResults.Any() ? QuizResults.Average(q => q.Score) : 0;
//    }

//    // Quiz Result
//    public class QuizResult
//    {
//        public string QuizName { get; set; }
//        public double Score { get; set; }
//    }

//    // Question Class
//    public class Question
//    {
//        public string Text { get; set; }
//        public string Answer { get; set; }
//        public string Subject { get; set; }
//    }

//    // Interfaces for DI
//    public interface IQuizService
//    {
//        event Action<Student, QuizResult> QuizCompleted;
//        void OnQuizCompleted(Student student, QuizResult result);
//        Task<List<Question>> LoadQuestionsAsync(string filePath);
//    }

//    public interface IStudentService
//    {
//        void SaveProgress(Student student);
//    }

//    // Quiz Service Implementation
//    public class QuizService : IQuizService
//    {
//        public event Action<Student, QuizResult> QuizCompleted;

//        public void OnQuizCompleted(Student student, QuizResult result)
//        {
//            QuizCompleted?.Invoke(student, result);
//        }

//        public async Task<List<Question>> LoadQuestionsAsync(string filePath)
//        {
//            var questions = new List<Question>();
//            filePath = "D:\\Module 3 Task\\Student Learning Tracker\\Student Learning Tracker\\SOT.txt";
//            var lines = await File.ReadAllLinesAsync(filePath);
//            foreach (var line in lines)
//            {
//                var parts = line.Split(",");
//                questions.Add(new Question { Text = parts[0], Answer = parts[1], Subject = parts[2] });
//            }
//            return questions;
//        }
//    }

//    // Student Service Implementation
//    public class StudentService : IStudentService
//    {
//        public void SaveProgress(Student student)
//        {
//            var file = $"{student.Name}_Progress.txt";
//            using (var sw = new StreamWriter(file))
//            {
//                sw.WriteLine($"Student: {student.Name}, Avg Score: {student.AverageScore()}");
//                foreach (var result in student.QuizResults)
//                {
//                    sw.WriteLine($"{result.QuizName}: {result.Score}");
//                }
//            }
//        }
//    }
//}




//using Student_Learning_Tracker;
//using System.Reflection;

//namespace Student_Learning_Tracker
//{
//    class Program
//    {
//        static async Task Main(string[] args)
//        {









            //IQuizService quizService = new QuizService();
            //IStudentService studentService = new StudentService();

            //quizService.QuizCompleted += (student, result) =>
            //{
            //    Console.WriteLine($"Quiz '{result.QuizName}' completed by {student.Name} with score {result.Score}%");
            //    studentService.SaveProgress(student);
            //};

            //var student = new Student { Id = 1, Name = "Alice" };
            //var questions = await quizService.LoadQuestionsAsync("questions.txt");

            //student.TakeQuiz(questions, (q, ans) => q.Answer.Equals(ans, StringComparison.OrdinalIgnoreCase), quizService);

            //// Reflection Example
            //Console.WriteLine("Tracked Methods:");
            //var methods = typeof(Student).GetMethods()
            //    .Where(m => m.GetCustomAttribute<TrackProgressAttribute>() != null);
            //foreach (var method in methods)
            //{
            //    Console.WriteLine(method.Name);
            //}
//        }
//    }
//}
