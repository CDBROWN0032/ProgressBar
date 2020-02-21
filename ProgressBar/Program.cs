using System;
using System.Threading;

namespace ProgressBar
{
    class Program
    {
        static void Main(string[] args)
        {
            WelcomeMessage();

            PercentComplete("Uploading Files...", 4, true);                            
        }


        static void PercentComplete(string message, int total, bool test = false)
        {
            int percentComplete;
            int currentIndex;
            var location = "Place";
            var errorCount = 1;

            for (int i = 0; i <= total; i++)
            {
                currentIndex = i > 0 ? i : 1;
                percentComplete = ((100 * (i)) / total);
                Console.Write($"\r{message} {percentComplete}% complete");
                if (currentIndex == total)
                {
                    Console.WriteLine(Environment.NewLine);
                    Console.WriteLine($"Files Uploaded to {location} with {errorCount} error(s).");

                }

                if(test)
                    Thread.Sleep(100);
            }
            
            Console.ReadKey();
        }

        static void WelcomeMessage()
        {
            Console.WriteLine("CMS File Uploader v1.0");
            Console.WriteLine("Commands:");
            Console.WriteLine("");
        }

    }
}
