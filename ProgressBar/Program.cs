using System;
using System.IO;
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
                    case Commands.Exit:
                        Environment.Exit(0);
                        break;
                    case Commands.TestBar:
                        PercentComplete("Uploading Files...", 75, true);
                        break;
                    case Commands.Help:
                        CommandsList();
                        break;
                    case Commands.Directory:
                        Console.WriteLine("Provide file(s) directory:");
                        GetFilesFromDirectory(Console.ReadLine());
                        break;
                    case Commands.TestDirectory:
                        GetFilesFromDirectory(@"E:\_homeRepo\_testFile");
                        break;
                    case Commands.TestDirectoryFail:
                        GetFilesFromDirectory(@"E:\_homeRepo\_thisFolderDoesNotExist");
                        break;

                    default:
                        Console.WriteLine("Invalid Command.\n");
                        break;
                }
            }
            while (command != Commands.Exit);
        }

        static void GetFilesFromDirectory(string directory)
        {
            if (Directory.Exists(directory))
            {
                var files = Directory.GetFiles(directory);
                Console.WriteLine($"\nFiles found: {files.Length}");
            }
            else
            {
                Console.WriteLine($"\n!Error: Proivded directory path not found.\nDirectory:{directory}");
            }
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

                if (test)
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
            Console.WriteLine($"{Commands.TestDirectory}   .  directory drill test");
            Console.WriteLine($"{Commands.TestDirectoryFail}  fail directory test");
            Console.WriteLine($"{Commands.TestBar}   .  .  .  test loading bar");
            Console.WriteLine("");
            Console.WriteLine($"{Commands.Help}      .  .  .  show command list");
            Console.WriteLine($"{Commands.Directory} .  .  .  provide file(s) directory");
            Console.WriteLine($"{Commands.Exit}      .  .  .  exit app");
        }

        static void NotImplemented()
        {
            Console.WriteLine("Command not Implemented.");
        }

        static class Commands
        {
            public const string Exit = "exit";
            public const string TestBar = "test_bar";
            public const string Help = "help";
            public const string Directory = "directory";
            public const string TestDirectory = "test_directory";
            public const string TestDirectoryFail = "test_directory_fail";
        }

    }
}
