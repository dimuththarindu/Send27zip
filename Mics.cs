using System;
using System.Threading.Tasks;

namespace Send27zip
{
    public class Mics
    {
        public void centerText(String text)
        {
            Console.Write(new string(' ', (Console.WindowWidth - text.Length) / 2));
            Console.WriteLine(text);
        }

        public async Task ApplicationExitAsync()
        {
            // Automatically Exit in 5 seconds
            await Task.Delay(5000);
            Environment.Exit(0);
        }
    }
}