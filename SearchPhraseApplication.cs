using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {

        //Maximum Concurrent Tasks at a time
        const int maxThreads = 16;

        //The search String
        static string searchString;
        static string targetPath;

        static int count = 0;
        static void Main(string[] args)
        {
            Console.WriteLine("Enter The Target Directory Path (Ex: C:\\SearchFolder\\)");
            targetPath = @"" + Console.ReadLine();           
            while (!Directory.Exists(targetPath))
            {
                Console.WriteLine("Target Directory Does Not Exist");
                Console.WriteLine("Enter Valid Target Directory Path (Ex: C:\\SearchFolder\\)");
                targetPath = @"" + Console.ReadLine();
            }
            Console.WriteLine("Enter The Phrase or String to be searched:");
            searchString = Console.ReadLine();

            Task.Run(async () => await ProcessFiles()).GetAwaiter().GetResult();

            Console.ReadLine();
        }
        public async static Task ProcessFiles()
        {
            //Using Stopwatch to Calculate the total execution time in seconds
            Stopwatch sw = new Stopwatch();

            sw.Start();
            var runningTasks = new List<Task>();
            var fileQueue = new Queue<string>();
            try
            {
                // Read all file names from the directory
                IEnumerable<string> fileEntries = Directory.EnumerateFiles(targetPath, "*.txt");

                //Add all the file names to Queue for Processing
                foreach (var file in fileEntries)
                {
                    fileQueue.Enqueue(file);
                }

                while (fileQueue.Count > 0)
                {
                    // queue up files to process;
                    while (runningTasks.Count < maxThreads && fileQueue.Count > 0)
                    {
                        runningTasks.Add(ProcessFileAsync(fileQueue.Dequeue()));
                    }

                    var completedTask = await Task.WhenAny(runningTasks).ConfigureAwait(false);

                    //Once Completed remove that task from running tasks
                    runningTasks.Remove(completedTask);
                }

                await Task.WhenAll(runningTasks).ConfigureAwait(false);

                TimeSpan elapsedTime = sw.Elapsed;
                string executionTime = elapsedTime.Seconds + "seconds";
                Console.WriteLine("executionTime " + executionTime);
                sw.Reset();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception Occcured: {0}", e.Message);
            }
        }

        public static async Task ProcessFileAsync(string fileName)
        {
            //Read File Data        
            var fileData = await ReadFileAsync(fileName).ConfigureAwait(false);

            //Frequency of the give string in the file
            var stringFrequency = await Task.Run(() => FindMatchAsync(fileData)).ConfigureAwait(false);
            Console.WriteLine("Sl: {0} Filename:{1} Count:{2} ", ++count, fileName, stringFrequency);
        }

        private static int FindMatchAsync(string fileData)
        {
            int fig_count = Regex.Matches(fileData, @"" + searchString, RegexOptions.IgnoreCase).Count;
            return fig_count;
        }

        private static async Task<string> ReadFileAsync(string fileName)
        {
            string fs = File.ReadAllText(fileName);
            return fs;
        }
    }
}
