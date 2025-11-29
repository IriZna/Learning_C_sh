using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW251125
{
    
    
 
    internal class Program
    {
        static void Main(string[] args)
        {
            //Տրված է string, որը բաղկացած է միայն փակագծերից՝ () { } []
            //Գրել method՝ որը ստուգում է՝ արդյոք փակագծերը ճիշտ են բացվել և փակվել։
            //Օրինակներ՝
            //● "()" → true
            //● "([])" → true
            //● "([)]" → false
            //● "{[()()]}" → true
            //● "(((" → false

            Console.WriteLine(StackExample("([])"));
            Console.WriteLine(StackExample("([)]"));
            Console.WriteLine(StackExample("((()"));
            Console.WriteLine(StackExample("((("));
            Console.WriteLine(StackExample("{[()()]}"));

            //-------------------Hw251125
            Message message;
            
            message = new ErrorMessage();
            message.Print();
            message = new SuccessMessage();
            message.Print();

            //Animal[] animals = new Animal[]
            //  { new Cat{ Name= "Tor" },
            //    new Cow {Name="Burenka"},
            //    new Dog {Name="Reks"},
            //    new Dog {Name="Pirat"},
            //    new Cow {Name="Murenka"},
            //    new Cat {Name="Barsik"}
            //   };
            Animal[] animals = new Animal[]
              { new Cat("Burenka"),
                new Dog ("Reks"),
                new Dog ("Pirat"),
                new Cow ("Murenka"),
                new Cat ("Barsik")
               };

            foreach (var animal in animals)
            {
                animal.Speak();
            }
            
        }
        public static bool StackExample(string str)
        {

            char[] chars = str.ToCharArray();

            char[] stack = new char[chars.Length];
            stack[0] = chars[0];
            int j = 1;
            int k = 0;
            if ((char)stack[0] != 91 && (char)stack[0] != 40 && (char)stack[0] != 123) { return false; }

            for (int i = 1; i < chars.Length; i++)
            {
                if ((char)chars[i] == 91 || (char)chars[i] == 40 || (char)chars[i] == 123)
                {
                    stack[j] = chars[i];
                    j++; continue;
                }
                char lastcode = (char)stack[j - 1 - k];
                if ((int)chars[i] > (int)lastcode + 2 && (int)chars[i] > (int)lastcode + 1) { return false;}
               
                k++;
            }
            if (k != j)  {return false; }
            return true;
        }
    }

}
