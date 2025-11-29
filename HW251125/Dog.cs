using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW251125
{
    public class Dog : Animal
    {
        public Dog(string name) : base(name) { }
        public override void Speak() => Console.WriteLine($"{Name} Woof!");
    }
}
