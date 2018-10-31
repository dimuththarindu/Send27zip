using System;
using System.Diagnostics;

namespace Send27zip
{
    class Program
    {        
        static SevenZip sevenZip = new SevenZip();
        static Configuration configuration = new Configuration();
        static Mics mics = new Mics();

        private static void Main(string[] args)
        {            
            Stopwatch watch = Stopwatch.StartNew();

            Console.ForegroundColor = ConsoleColor.White;
            Console.Title = "7zip Command line";
            Console.WriteLine(string.Empty);
            mics.centerText("Starting 7zip...");

            //Testing();

            if (args != null && args.Length > 0)
            {
                sevenZip.Start7zip(args);
            }
            else
            {         
                Console.WriteLine(String.Empty);
                Console.WriteLine("Press any key if you want to configure...");
                Console.ReadKey();

                configuration.PasswordManage();
                configuration.ArchiveFormatManage();                
                configuration.CompressionLevel();
            }

            watch.Stop();
            long elapsedMs = watch.ElapsedMilliseconds;

            
            Console.WriteLine(string.Empty);
            mics.centerText("Process is done.");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            mics.centerText("Elapsed time in Milliseconds: " + elapsedMs);
            Console.ReadKey();
            Environment.Exit(0);     
        }

        private static void Testing()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(string.Empty);
            mics.centerText("Testing mode has been enabled");
            Console.ForegroundColor = ConsoleColor.White;

            //string[] args = new string[2];
            string[] args = new string[1];

            //args[0] = @"D:\Testing\New Text Document.txt";
            args[0] = @"D:\Testing\New folder";

            // Password should be set to call this method.
            sevenZip.Start7zip(args);

            Console.WriteLine(string.Empty);
            mics.centerText("Testing is done.");
            mics.centerText("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
