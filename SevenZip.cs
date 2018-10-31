using System;
using System.Diagnostics;
using System.IO;

namespace Send27zip
{
    public class SevenZip
    {
        string exeLocation = @"C:\Program Files\7-Zip\7zG.exe";
        string sourceLocation = "";
        string AllSourceLocation = "";
        string targetLocation = "";
        string argument = "";
        string passwordEnable = "No";

        string password = "";
        string archiveFormat = "";
        string compressionLevel = "";

        public SevenZip()
        {
            password = Properties.Settings.Default["Password"].ToString();
            archiveFormat = Properties.Settings.Default["ArchiveFormat"].ToString();
            compressionLevel = "-mx=" + Properties.Settings.Default["CompressionLevel"].ToString();

            if (password != string.Empty)
            {
                password = "-p" + password + " ";
                passwordEnable = "Yes";
            }
            //else
            //{
            //    passwordEnable = "No";
            //}
        }

        private string ArgumentSelection()
        {
            //argument = "a -t7z \"" + targetLocation + "\" " + AllSourceLocation + " -p1111 -m0=lzma -mx=9 -mfb=273 -ms=on -mmt=on -mhc=on -mhe=on";
            if (archiveFormat == "zip")
            {
                argument = "a -tzip \"" + targetLocation + "\" " + AllSourceLocation + " " + password + compressionLevel + " -mfb=258 -mpass=20";
            }
            else
            {
                argument = "a -t7z \"" + targetLocation + "\" " + AllSourceLocation + " " + password + compressionLevel + " -m0=lzma -mfb=273 -ms=on -mmt=on -mhc=on -mhe=on";
            }

            return argument;
        }

        public void Start7zip(string[] locations)
        {            
            sourceLocation = locations[0];
            //sourceLocation = @"D:\Testing\7zFM";

            AllSourceLocation = "\"" + string.Join("\" \"", locations) + "\"";
            Console.WriteLine("All selected files & folders");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("- " + string.Join(Environment.NewLine + "- ", locations));
            Console.ForegroundColor = ConsoleColor.White;

            if (locations.Length > 1)
            {
                // if multiple files are selected, file name will be same as main directory name
                targetLocation = Path.GetDirectoryName(sourceLocation) + "\\" + Path.GetFileName(Path.GetDirectoryName(sourceLocation)) + "." + archiveFormat;
            }
            else
            {
                // if only one file is selected, file name will be same
                targetLocation = Path.GetDirectoryName(sourceLocation) + "\\" + Path.GetFileNameWithoutExtension(sourceLocation) + "." + archiveFormat;
            }

            //argument = "a -t7z \"" + targetLocation + "\" " + AllSourceLocation + " -p1111 -m0=lzma -mx=9 -mfb=273 -ms=on -mmt=on -mhc=on -mhe=on";

            #region Metadata 
            // Testing
            // 14737KB | Default lzma2
            // 14783KB | "a -t7z \"" + targetName + "\" \"" + sourceName + "\" -pDT9393 -m0=lzma -mx=9 -mfb=273 -ms=on -mmt=on -mhc=on -mhe=on";
            // 15447KB | "a -t7z \"" + targetName + "\" \"" + sourceName + "\" -pDT9393 -m0=lzma -mx=9 -mfb=258 -md=32m -ms=on -mmt=on -mhc=on -mhe=on";
            // 16277KB | Default lzma2
            // 16277KB | "a -t7z \"" + targetName + "\" \"" + sourceName + "\" -pDT9393 -m0=lzma2 -mx=9 -mfb=273 -ms=on -mmt=on -mhc=on -mhe=on";

            // Source: Medium
            // 7-Zip options for ultimate compression
            // For large text files: 7z a -mx=9 -mfb=273 -ms=on archive.7z <input files>
            // For small text files: 7z a -m0=PPMd -mx=9 -ms=on archive.7z <input files>    
            // maximum ZIP file compression (compatible with other tools): 7z a -tzip -mx=9 -mfb=258 -mpass=20 archive.zip <input files>
            //
            // Options that didn’t help
            // t7z, -m0 = lzma : These are the default.
            // m0 = lzma2, -m0 = PPDm : These compressors are not as good as LZMA.
            // md = 2147483647 : Maximizing the dictionary size only made the file a few bytes larger. It might be of benefit for very large archives.
            // mmt = off : No effect.
            // mmc = 2147483647 : No effect, not sure why.
            // mlc = 4 : Made file larger.
            // Source End.
            // Source URL: https://medium.com/@dcoetzee/7-zip-options-for-ultimate-compression-595a037b1a48

            // 7zip Compression levels
            // Switch - mx0: Don't compress at all. This is called "copy mode."
            // Switch - mx1: Low compression. This is called "fastest" mode.
            // Switch - mx3: Fast compression mode. Will automatically set various parameters.
            // Switch - mx5: Same as above, but normal. 
            // Switch - mx7: This means "maximum" compression.
            // Switch - mx9: This means "ultra" compression. 

            // Type switches
            // Switch: -t7z    Format: 7Z(default option)
            // Switch: -tgzip  Format: GZIP
            // Switch: -tzip   Format: ZIP(compatible)
            // Switch: -tbzip2 Format: BZIP2
            // Switch: -ttar   Format: TAR(UNIX and Linux)
            // Switch: -tiso   Format: ISO(may not be supported)
            // Switch: -tudf   Format: UDF

            // Options
            // a: add to archive
            // -mmt: multithread the operation(faster)
            // -pSECRET: specify the password "SECRET"

            // m={MethodID}             Deflate:   Copy, Deflate, Deflate64, BZip2, LZMA, PPMd.
            // fb={NumFastBytes}        32:        Sets number of Fast Bytes for Deflate encoder.
            // pass={NumPasses}         1:         Sets number of Passes for Deflate encoder.
            // d={Size}[b|k|m]          900000     Sets Dictionary size for BZip2
            // mem={Size}[b|k|m]        24         Sets size of used memory for PPMd.
            // o={Size}                 8          Sets model order for PPMd.
            // mt=[off|on|{N}]          on         Sets multithreading mode.
            // em={EncryptionMethodID}  ZipCrypto  Sets a encryption method: ZipCrypto, AES128, AES192, AES256
            // tc=[off|on]              off        Stores NTFS timestamps for files: Modification time, Creation time, Last access time.
            // cl=[off|on]              off        Zip always uses local code page for file names.
            // cu=[off|on]              off        7-Zip uses UTF-8 for file names that contain non-ASCII symbols.
            #endregion

            Console.WriteLine(String.Empty);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Archive Format: " + archiveFormat);
            Console.WriteLine("Compression Level: " + Properties.Settings.Default["CompressionLevel"].ToString());
            Console.WriteLine("Password Enabled: " + passwordEnable);
            Console.ForegroundColor = ConsoleColor.White;

            ProcessStartInfo start = new ProcessStartInfo();
            start.Arguments = ArgumentSelection();
            start.FileName = exeLocation;
            start.WindowStyle = ProcessWindowStyle.Normal;

            using (Process proc = Process.Start(start))
            {
                proc.WaitForExit();
            }
        }
    }
}
