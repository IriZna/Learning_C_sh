using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a Path: ");
            string path = Console.ReadLine();
            int fcount = 0;
            
            try
            {
                
                foreach (string fd in Directory.EnumerateFiles(path,"*", SearchOption.AllDirectories))
                {
                    try
                    {
                        FileInfo fileInfo = new FileInfo(fd);
                        string fsize = fileInfo.Length < 1024? $"{fileInfo.Length} bytes" 
                            : fileInfo.Length < 1024 * 1024? $"{fileInfo.Length / 1024} Kb" :  $"{fileInfo.Length / (1024 * 1024)} Mb" ;
                        Console.WriteLine($"Name: {fileInfo.FullName,-90} |Extension: {fileInfo.Extension} | Creation Time {fileInfo.CreationTime} | Size {fsize } ");
                        fcount++;
                    }
                    catch (FileNotFoundException ex)
                    {
                        Console.WriteLine($" File not accessible: {Path.GetFileName(fd)}");
                    }
                    catch(FieldAccessException ex) 
                    {
                        Console.WriteLine($"Access denied to file: {path}");
                    }
                    catch (Exception ex) { Console.WriteLine($"Error:{ex.Message}"); }
                    
                }
                Console.WriteLine($"Total {fcount}");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine($"Access denied to directory: {path}");
            }

            catch (DirectoryNotFoundException)
            {
                Console.WriteLine($"Directory not accessible: {path}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

        }
    }
}
