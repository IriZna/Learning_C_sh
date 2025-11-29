using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW251125
{
    public class Animal
    {
        public string Name { get; set; }

        public Animal(string name)
        { Name = name; }

        public virtual void Speak() => Console.WriteLine("Animal sound");
    }


}
