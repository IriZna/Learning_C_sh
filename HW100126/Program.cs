using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW100126
{
    internal class Program
    {
        class MyException:Exception
        {
            public MyException(string message):base(message) 
            { 
            }
            
        }
        static void Main(string[] args)
        {
           
            var path = Directory.GetParent(Directory.GetCurrentDirectory())?.Parent.FullName + "\\Logs";
            var fileName = "app.log";
            var pathFile = (path +"\\"+ fileName);
            
            //Console.WriteLine(Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent);
            //Console.WriteLine($"Directory Exists: {Directory.Exists(path)}");
            
            Directory.CreateDirectory(path);
            
            
            Console.WriteLine(Path.GetFullPath(path));
            var content = " The recording of information into the log file has begun.";
            if (File.Exists(pathFile)) 
            {
                using (var fs = new FileStream(pathFile, FileMode.Append, FileAccess.Write))
                using (var sw = new StreamWriter(fs, Encoding.UTF8))
                { sw.WriteLine($"{DateTime.Now} {content}"); }
            }
            else
            {
                using (var fs = new FileStream(pathFile, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                using (var sw = new StreamWriter(fs, Encoding.UTF8))
                { sw.WriteLine($"{DateTime.Now} {content}"); }
            }
 
            Console.WriteLine("Enter a number: ");

            string input = Console.ReadLine();
            Console.WriteLine(input);

            try
            {
                TenFoldValue(input);
            }
            catch (MyException ex)
            {
                
                using (var fs = new FileStream(pathFile, FileMode.Append, FileAccess.Write))
                using (var sw = new StreamWriter(fs, Encoding.UTF8))
                { sw.WriteLine($"{DateTime.Now}  {ex.Message}"); }

               // Console.WriteLine(ex.Message);
            }

            finally
            {
                using (var fs = new FileStream(pathFile, FileMode.Append, FileAccess.Write))
                using (var sw = new StreamWriter(fs, Encoding.UTF8))
                { sw.WriteLine($"{DateTime.Now}  Process completed"); }
                Console.WriteLine($"The log file is located {pathFile} ");
            }


            using (var sr = new StreamReader(pathFile, Encoding.UTF8))
            {
                string ftext=sr.ReadToEnd();
                Console.WriteLine(ftext);
            }

        }
        static void TenFoldValue(string input)
        {
            try
            {
                int num = checked(int.Parse(input) * 10);
                Console.WriteLine($"Your entered number is {num}");
            }
            catch (FormatException ex)
            {
                throw new MyException($" Input string was not in a correct format, Pls,enter a number. {ex}");

            }
            catch (OverflowException ex)
            {
                throw new MyException($" The range of the entered number  must be between {int.MinValue / 10} and {int.MaxValue / 10}");

            }
            catch (Exception ex)
            {
                throw new MyException($" Unknow error {ex} ");

            }
        }

        }
}
