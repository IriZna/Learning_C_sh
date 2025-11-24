using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3
{
    struct Triangle
    {
        public double BASE { get; set; }
        public double Height { get; set; }

        public Triangle(double @base, double @height)
        {
            BASE = @base;
            Height = @height;
        }
        public double GetTriangleArea()
        {
            return BASE * Height * 0.5;
        }
    }
}
