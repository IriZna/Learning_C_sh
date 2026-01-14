using System;
using System.Collections.Generic;
using System.Diagnostics;
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
             
            Console.WriteLine("Enter a number: ");
            string input = Console.ReadLine();
           
            try
            {
                TenFoldValue(input);
            }
            catch (MyException ex)
            {
                Console.WriteLine( ex.Message);
            }
            finally
            {
                Console.WriteLine("Process completed");
            }
            Console.WriteLine("Finish");

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
                throw new MyException($" Input string was not in a correct format, Pls,enter a number. ");

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
