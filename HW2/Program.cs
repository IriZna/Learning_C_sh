using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace HW2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //1.Անհրաժեշտ է գրել մեթոդը, որը ստանում է ամբողջ թվերի զանգված և ստեղծում է նոր string որի էլեմենտները ստորակետով բաժանված են:

            //int [] arr = CreateMatrix(10, 1, 10);

            //for (int i = 0; i < arr.Length; i++)
            //{
            //    Console.Write(arr[i] + " ");
            //}
            //Console.WriteLine();

            //string newStr = string.Join(",", arr);
            //Console.WriteLine(newStr);

            //2.Օգտագործելով StringBuilder՝ հավաքել string, որը ունի n կրկնվող pattern՝ օրինակ՝ "ABC" pattern - ը կրկնել n անգամ առանց որևէ ժամանակավոր string ստեղծելու,
            //Օրինակ n = 4 "ABCABCABCABC"
            //int n = 10;

            //StringBuilder sb = new StringBuilder(3*n);
            //for (int i = 0;i<n;i++)
            //{
            //    sb.Append("ABC");
            //}

            //Console.WriteLine(sb.ToString());

            //3.Անհրաժեշտ է ստեղծել Rectangle և Triangle struct տիպերը որը իր տիպին համապատասխան կունենա width, height կամ base, height դաշտերով։ Գրիր մեթոդ որը վերադարձնում է մակերեսը։

            //var triangle = new Triangle(11, 15);
            //double areatr = triangle.GetAreaTr();
            //Console.WriteLine(areatr);

            //var rectangle = new Rectangle(11, 15);
            //double area = rectangle.GetAreaRect();
            //Console.WriteLine(area);


            //4. Անհրաժեշտ է ստեղծել Point անունով struct տիպ, որը կունենա երկու դաշտ՝ X և Y։
            //Այնուհետև պետք է ստեղծել 10 էլեմենտից բաղկացած զանգված այս struct տիպով և լցնել այն պատահական(Random) X և Y արժեքներով։
            //Վերջում անհրաժեշտ է ստեղծել նոր զանգված, որտեղ Point-երը կլինեն դասակարգված աճման կարգով՝ նախ ըստ X-ի, իսկ եթե X-երը հավասար են՝ ըստ Y-ի։
            //Նախկան լուծման արդյունքը տպելը անհրաժեշտ է նաև տպել զանգվածը։

            Point[] arrpoints = new Point[10];
            Random random = new Random();

            for (int i = 0; i < arrpoints.Length; i++)
            {
                arrpoints[i] = new Point( random.Next(0, 10),  random.Next(0, 10));
                
            }
            Point[] sortpoints= arrpoints.OrderBy(p => p.X).ThenBy(p=>p.Y).ToArray();
            foreach (var point in arrpoints)
            {
                Console.WriteLine(point);
            }
            Console.WriteLine();
            foreach (var point in sortpoints)
            {
                Console.WriteLine(point);
            }


        }
        
        static int[] CreateMatrix(int arrDimension, int RandRrangeMin, int RandRrangeMax)
        {
            Random random = new Random();

            int[] arr = new int[arrDimension];
            for (int i = 0; i < arrDimension; i++)
            {
                arr[i] = random.Next(RandRrangeMin, RandRrangeMax);
            }

            return arr;
        }
        static int[,] CreateMatrix(int x, int y, int RandRrangeMin, int RandRrangeMax)
        {
            Random random = new Random();

            int[,] arr = new int[x, y];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = random.Next(RandRrangeMin, RandRrangeMax);
                }

            }

            return arr;
        }

        
        
                   
  

        

    }

    readonly struct Rectangle
    {
        public int Width { get; }
        public int Height { get; }

        public Rectangle(int w, int h)
        {
            Width = w;
            Height = h;
        }

        public int GetAreaRect()
        {
            return Width * Height;
        }
    }
    readonly struct Triangle
    {
        public double Base { get; }
        public double Height { get; }

        public Triangle(double a, double h)
        {
            Base = a;
            Height = h;
        }

        public double GetAreaTr()
        {
            return (Base * Height/2);
        }
    }
    struct Point
    { 
      public int X { get; } 
      public int Y { get; } 

        public Point(int x, int y)
        {
            X = x; 
            Y = y;
        }
        public override string ToString()
        {
            return $"{X},{Y}";
        }
        
    }


}
