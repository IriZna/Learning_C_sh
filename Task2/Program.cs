using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var path = "Logs";
            var fileName = "app.log";
            var pathFile = (path + "\\" + fileName);

            Directory.CreateDirectory(path);

            if (File.Exists(pathFile))
            {
                FileWriter(pathFile, FileMode.Append, FileAccess.Write, Encoding.UTF8, " Append info in exists file");
            }
            else
            {
                FileWriter(pathFile, FileMode.OpenOrCreate, FileAccess.ReadWrite, Encoding.UTF8, " Create new file ");
            }

            StreamReader(pathFile, Encoding.UTF8);
        }
        static void FileWriter(string path, FileMode modefile, FileAccess accessfile, Encoding encodingText, string message)
        {
            using (var fs = new FileStream(path, modefile, accessfile))
            using (var sw = new StreamWriter(fs, Encoding.UTF8))
            { sw.WriteLine($"{DateTime.Now}  {message}"); }

        }
        static void StreamReader(string path, Encoding  encodingText)
        {
           
           using (var sr = new StreamReader(path, encodingText))
            {
                string ftext = sr.ReadToEnd();
                Console.WriteLine(ftext);
            }

        }
    }
}
