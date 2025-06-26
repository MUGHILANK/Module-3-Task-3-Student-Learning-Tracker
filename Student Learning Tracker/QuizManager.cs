using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Learning_Tracker
{
    public static class QuizManager
    {
        // Asynchronously load questions from a file (one question per line)
        public static async Task<List<string>> LoadQuestionsAsync(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Questions file not found.");
                return new List<string>();
            }

            var lines = await File.ReadAllLinesAsync(filePath);
            return lines.ToList();
        }

        // Submit quiz results in the background (append to a file)
        public static void SubmitQuizResultsInBackground(string filePath, string result)
        {
            Task.Run(async () =>
            {
                await File.AppendAllTextAsync(filePath, result + Environment.NewLine);
                Console.WriteLine("Quiz result submitted in background.");
            });
        }
    }
}