using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3
{
    struct Student
    {
        public string Name { get; set; }
        public int[] Scores { get; set; }
        public Student(string name, int[] scores)
        {
            Name = name; Scores = scores;
        }
        public double AverageScores()
        {
            double sumscores = 0;

            foreach (double s in Scores)
            {
                sumscores+=s;
            }
            return sumscores/Scores.Length;
        }
        public override string ToString()
        {
            return $"{Name},{Scores}";
        }
    }
}
