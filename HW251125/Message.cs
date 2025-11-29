using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW251125
{
    public class Message
    {
        public virtual void Print() => Console.WriteLine("Generic message");

    }
    public class ErrorMessage:Message
    {
        public override void Print()=> Console.WriteLine("Error occurred!");
        
    }
    public class SuccessMessage:Message
    {
        public override void Print()=> Console.WriteLine("Operation successful!");
        
    }
}
