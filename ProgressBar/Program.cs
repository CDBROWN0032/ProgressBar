using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;

namespace ProgressBar
{
    class Program
    {                
        static void Main(string[] args)
        {
            Run();
        }

        static void Run()
        {
            WelcomeMessage();
            CommandsList();

            string command;
            do 
            {                
                command = Console.ReadLine();
                switch (command)
                {
                    case Commands.ExitCommand:                         
                        Environment.Exit(0); 
                        break;
                    case Commands.TestBar:
                        PercentComplete("Uploading Files...", 75, true); 
                        break;
                    case Commands.Help:
                        CommandsList(); 
                        break;
                    case Commands.Directory:
                        NotImplemented();
                        break;

                    default:
                        Console.WriteLine("Invalid Command.\n");
                        break;
                }


            }
            while (command != Commands.ExitCommand);

        }

        static void PercentComplete(string message, int total, bool test = false)
        {
            int percentComplete;
            int currentIndex;
            string spinner;
            var location = "Place";
            var errorCount = 1;
            
            Console.Clear();

            for (int i = 0; i <= total; i++)
            {
                spinner = SpinnerLoadBar(i, total);
                currentIndex = i > 0 ? i : 1;
                percentComplete = ((100 * (i)) / total);
                Console.Write($"\r{message} {spinner} {percentComplete}% complete");
                if (currentIndex == total)
                {
                    Console.WriteLine(Environment.NewLine);
                    Console.WriteLine($"Files Uploaded to {location} with {errorCount} error(s).");

                }

                if(test)
                    Thread.Sleep(100);
            }
        }

        static string SpinnerLoadBar(int index, int total)
        {
            if (index == total)
                return string.Empty;

            switch (index % 6)
            {
                case 0: return "[    ]"; 
                case 1: return "[=   ]";
                case 2: return "[==  ]"; 
                case 3: return "[=== ]"; 
                case 4: return "[ ===]"; 
                case 5: return "[  ==]"; 
                case 6: return "[   =]"; 
                default: return "spinner errored out";
            }
        }

        static void WelcomeMessage()
        {
            Console.WriteLine("************************************");
            Console.WriteLine("*                                  *");
            Console.WriteLine("*  --  CMS File Uploader v1.0  --  *");
            Console.WriteLine("*                                  *");
            Console.WriteLine("************************************");
        }

        static void CommandsList()
        {
            Console.WriteLine("Commands:\n");
            Console.WriteLine("help      .  .  .  show command list");
            Console.WriteLine("testbar   .  .  .  test loading bar");
            Console.WriteLine("directory .  .  .  provide file(s) directory");
            Console.WriteLine("exit      .  .  .  exit app");
        }

        static void NotImplemented()
        {
            Console.WriteLine("Command not Implemented.");
        }

        public static class Commands
        {
            public const string ExitCommand = "exit";
            public const string TestBar = "testbar";
            public const string Help = "help";
            public const string Directory = "directory";
        }

    }
}
