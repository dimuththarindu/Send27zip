using System;

namespace Send27zip
{
    public class Configuration
    {
        Mics mics = new Mics();

        public void PasswordManage()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            mics.centerText("Setting Password");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(String.Empty);
            Console.WriteLine("Your current password: " + Properties.Settings.Default["Password"]);

            Console.WriteLine("Please enter a new password... ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("If you don't want a password, please just press enter");
            Console.ForegroundColor = ConsoleColor.White;
            string password = Console.ReadLine();
            Properties.Settings.Default["Password"] = password;
            Properties.Settings.Default.Save();

            if (password == string.Empty)
            {
                Console.WriteLine("No password");
            }
            else
            {
                Console.WriteLine("New password: " + Properties.Settings.Default["Password"]);
            }
        }

        public void ArchiveFormatManage()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            mics.centerText("Setting Archive Format");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(String.Empty);
            Console.WriteLine("Your current archive format: " + Properties.Settings.Default["ArchiveFormat"]);

            Console.WriteLine("Please select a new archive format... ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("1: .7z (High compression)");
            Console.WriteLine("2: .zip (Compatible)");
            Console.ForegroundColor = ConsoleColor.White;

            try
            {
                string archiveFormat = Console.ReadLine();

                if (archiveFormat == "1")
                {
                    Properties.Settings.Default["ArchiveFormat"] = "7z";
                    Properties.Settings.Default.Save();
                }
                else if (archiveFormat == "2")
                {
                    Properties.Settings.Default["ArchiveFormat"] = "zip";
                    Properties.Settings.Default.Save();
                }
                else
                {                   
                    throw new Exception("Input is not valid");
                }

                Console.WriteLine("New Archive Format: " + Properties.Settings.Default["ArchiveFormat"]);
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Your input is not valid. Please try again.");
                ArchiveFormatManage();
            }
        }

        public void CompressionLevel()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            mics.centerText("Setting Compression Level");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(String.Empty);
            Console.WriteLine("Your current compression level: " + Properties.Settings.Default["CompressionLevel"]);

            Console.WriteLine("Please select a new compression level... ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("0: Don't compress at all.");
            Console.WriteLine("1: Low compression");
            Console.WriteLine("2: ");
            Console.WriteLine("3: Fast compression mode");
            Console.WriteLine("4: ");
            Console.WriteLine("5: ");
            Console.WriteLine("6: ");
            Console.WriteLine("7: Maximum compression");
            Console.WriteLine("8: ");
            Console.WriteLine("9: Ultra compression");
            Console.ForegroundColor = ConsoleColor.White;

            try
            {
                string compressionLevel = Console.ReadLine();

                int value;

                if (int.TryParse(compressionLevel, out value))
                {
                    if ((value >= 0) && (value < 10))
                    {
                        Properties.Settings.Default["CompressionLevel"] = value;
                        Properties.Settings.Default.Save();
                    }
                    else
                    {
                        throw new Exception("Input is not valid");
                    }
                }
                else
                {
                    throw new Exception("Input is not valid");
                }

                Console.WriteLine("New Compression Level: " + Properties.Settings.Default["CompressionLevel"]);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Your input is not valid. Please try again.");
                //Console.WriteLine(ex.Message);
                CompressionLevel();
            }
        }
    }
}
