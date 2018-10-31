using System;
using System.Diagnostics;

namespace Send27zip
{
    class Program
    {
        static void Main(string[] args)
        {            
            Stopwatch watch = Stopwatch.StartNew();
            SevenZip sevenZip = new SevenZip();

            Console.Title = "7zip Command line";
            Console.WriteLine("Starting 7zip..." + Environment.NewLine);

            if (args != null && args.Length > 0)
            {
                sevenZip.Start7zip(args);
            }
            else
            {
                //doSomething();
            }

            watch.Stop();
            long elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine(Environment.NewLine + "Process is done." + Environment.NewLine + "Elapsed time in Milliseconds: " + elapsedMs);
            Console.ReadKey();
            Environment.Exit(0);     
        }

        static void doSomething()
        {
            //Console.WriteLine("Do something");
            //Process process = new Process();
            //ProcessStartInfo startInfo = new ProcessStartInfo();
            //startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            //startInfo.FileName = "explorer.exe shell:sendto";
            //startInfo.Arguments = "";
            //process.StartInfo = startInfo;
            //process.Start();
        }
    }
}
