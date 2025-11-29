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
    }

}
