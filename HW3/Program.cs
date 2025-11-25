using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HW3
{
    

    internal class Program
    {
        static void Main(string[] args)
        {
            //// HomeWork 221125
            //1.1.Ստեղծել C# ստրուկտուրա Student, որը կունենա հետևյալ դաշտերը՝ Name — string Scores — ամբողջ թվերի զանգված (օրինակ՝ 3,5,1,2,9,8) Ներմուծել աշակերտների քանակը: Յուրաքանչյուր աշակերտից ընդունել՝ Անունը (Name) Գնահատականների զանգվածը (Scores) 
            //    Լցնել բոլոր աշակերտների տվյալները հիմնական զանգվածում: Հաշվել և տպել յուրաքանչյուր աշակերտի միջին գնահատականը։
            
            //Console.Write("Number of students: ");
            //int count=int.Parse(Console.ReadLine());
            //Student[] student = GetStudentCourse(count);
            //foreach (Student s in student)
            //{                 
            //    Console.WriteLine(s.Name);
            //    Console.Write("Scores: ");
            //    Console.WriteLine(string.Join(",", s.Scores));
            //    Console.Write("Average score: ");
            //    Console.WriteLine(s.AverageScores());
            //}

            //2 Տրված է n x m չափի ամբողջ թվերի մատրիցա և սկսնակ կոորդինատներ (startX, startY)։ Պահանջվում է փոխել սկսնակ կետում գտնվող արժեքը նոր արժեքով
            //newValue և բոլոր այն հարևան կետերում, որոնք ունեն նույն հին արժեքը (վեր, վար, ձախ, աջ):(Սա չի նշանակում միայն տրված կոորդինատի հարևանի, այլ նաև հարևանի հարևանների
            //և այդպես շարունակ, քանի դեռ տրված կետում հին արժեք ունեն նաև հարևանները) Անհրաժեշտ է այն լուծել երկու տարբերակով 1. Առանց ռեկուսիա 1. Ռեկուսիա

            int[,] arr = new int[4, 5] { { 1, 1, 1, 1, 2 },  
                                         { 1, 0, 1, 2, 2},
                                         { 1, 0, 0, 2, 2},
                                         { 2, 1, 2, 2, 2}
                                        };

                        
           
            PrintArray(arr);
            Console.Write("Start X :");
            int starti=int.Parse(Console.ReadLine());
            Console.WriteLine();
            
            Console.Write("Start Y :");
            int startj = int.Parse(Console.ReadLine());
            Console.WriteLine();
            
            int oldval = arr[starti, startj];
            Console.Write("Old value =");
            Console.WriteLine(oldval);
            Console.WriteLine();
            
            Console.Write("New value :");
            int newval=int.Parse(Console.ReadLine());
            Console.WriteLine();

            //without recursion
            int maxi = arr.GetLength(0) - 1;
            int maxj = arr.GetLength(1) - 1;
            OutRecursionNew(arr, starti , startj, oldval, newval);
            int starti1 = starti;
            int startj1 = startj;
            int starti2 = starti;
            int startj2 = startj;
            int starti3 = starti;
            int startj3 = startj;
            int starti4 = starti;
            int startj4 = startj;

            while (starti1 >= 0 && startj1 >= 0 )
             {
                OutRecursionNew(arr, starti1-1 , startj1-1 , oldval, newval);
                starti1 -= 1; startj1 -= 1;
            }
            while (starti2 >= 0 && startj2 < maxj)
            {

                OutRecursionNew(arr, starti2 - 1, startj2 + 1, oldval, newval);
                starti2 -= 1; startj2 += 1;
            }
            while (starti3 < maxi && startj3 >= 0)
            {

                OutRecursionNew(arr, starti3 + 1, startj3 - 1, oldval, newval);
                starti3 += 1; startj3 -= 1;
            }

            while (starti4 < maxi && startj4 < maxj)
            {

                OutRecursionNew(arr, starti4 + 1, startj4 + 1, oldval, newval);
                starti4 += 1; startj4 += 1;
            }
            

            //with recursion

            //ChangeNeighborsWithRecursion(arr, starti, startj, oldval, newval);
            PrintArray(arr);




            //------------------HomeWork 201125---------------------------------------------------------

            ////1.Անհրաժեշտ է գրել մեթոդը, որը ստանում է ամբողջ թվերի զանգված և ստեղծում է նոր string որի էլեմենտները ստորակետով բաժանված են:

            //int[] arr= CreateMatrix(10,0,100);
            //string arrstr = GetStringSeparator(arr, ',');
            ////string arrstr = string.Join(",", arr);
            //Console.WriteLine(arrstr);


            ////2.Օգտագործելով StringBuilder՝ հավաքել string, որը ունի n կրկնվող pattern՝ օրինակ՝ "ABC" pattern-ը կրկնել n անգամ առանց որևէ ժամանակավոր string ստեղծելու, Օրինակ n = 4 "ABCABCABCABC"

            //string strpatern = GetStrPatern("ABS", 10);
            //Console.WriteLine(strpatern);
            ////3.Անհրաժեշտ է ստեղծել Rectangle և Triangle struct տիպերը որը իր տիպին համապատասխան կունենա width, height կամ base,
            ////height դաշտերով։ Գրիր մեթոդ որը վերադարձնում է մակերեսը։

            //Rectangle rectangle =new Rectangle(5, 7);
            //Triangle triangle = new Triangle(5, 7);

            //Console.WriteLine(rectangle.GetRectangleArea());
            //Console.WriteLine(triangle.GetTriangleArea());

            ////4.Անհրաժեշտ է ստեղծել Point անունով struct տիպ, որը կունենա երկու դաշտ՝ X և Y։
            ////Այնուհետև պետք է ստեղծել 10 էլեմենտից բաղկացած զանգված այս struct տիպով և լցնել այն պատահական(Random) X և Y արժեքներով։
            ////Վերջում անհրաժեշտ է ստեղծել նոր զանգված, որտեղ Point-երը կլինեն դասակարգված աճման կարգով՝ նախ ըստ X-ի, իսկ եթե X-երը հավասար են՝ ըստ Y-ի։
            //Console.WriteLine();

            //Point[] points=CreatePointRandomArray(10,0,10);
            //Point[] sortpoints=GetNewSortArray(points);
            //Console.WriteLine("ORIG");
            //PrintPointArray(points);

            //points = GetNewSortArray(points);

            //Console.WriteLine("SORT");
            //PrintPointArray(sortpoints);
            //Console.WriteLine("SORT the Same");
            //PrintPointArray(points);

        }

        

        static void OutRecursionNew(int[,] arr,int row, int col,int oldval, int newval)
        {
            int maxi = arr.GetLength(0)-1 ;
            int maxj = arr.GetLength(1)-1 ;
            for (int ni = -1; ni < 2; ni++)
            {
                if (row + ni < 0 || row + ni > maxi)
                {  break; }
                for (int nj = -1; nj < 2; nj++)
                {
                    if (col + nj < 0 || col + nj > maxj)
                    { break; }
                    if (arr[row + ni, col + nj] != oldval)
                    { break; }
                    
                    arr[row + ni, col + nj] = newval;
                }
            }
        }


        static void ChangeNeighborsWithRecursion(int[,] arr, int row, int col, int oldvalue, int newvalue)
        {
            int maxi = arr.GetLength(0) - 1;
            int maxj = arr.GetLength(1) - 1;


            if (row < 0 || row > maxi || col < 0 || col > maxj)
            { return; }
            if (arr[row, col] != oldvalue)
            { return; }

            arr[row, col] = newvalue;
            
            ChangeNeighborsWithRecursion( arr, row-1, col-1,  oldvalue, newvalue);
            ChangeNeighborsWithRecursion( arr, row-1, col,    oldvalue, newvalue);
            ChangeNeighborsWithRecursion( arr, row-1, col + 1,oldvalue, newvalue);

            ChangeNeighborsWithRecursion( arr, row  , col-1,  oldvalue, newvalue);
            ChangeNeighborsWithRecursion( arr, row,   col + 1,oldvalue, newvalue);

            ChangeNeighborsWithRecursion( arr, row+1, col-1,  oldvalue, newvalue);
            ChangeNeighborsWithRecursion( arr, row+1, col,    oldvalue, newvalue);
            ChangeNeighborsWithRecursion( arr, row+1, col+1,  oldvalue, newvalue);
            
            
        }
       

        static int[] GetScoresArrFromString(string scorestxt)
        {
            
            int count = 0;
            //int scoreslenght = scorestxt.Length;
            string num = "";
            for (int i = 0;i< scorestxt.Length; i++)
            {
                //char c = scorestxt[i];
                if (scorestxt[i]==',')
                {
                    if (num.Length > 0) { count++;num = ""; }
                }
                else
                {
                    if (char.IsDigit(scorestxt[i]))
                    num+= scorestxt[i];
                }

            }
            int [] scores = new int[count];
            int j = 0;
            for (int i = 0; i < scorestxt.Length; i++)
            {
                if (scorestxt[i] == ',')
                {
                    if (num.Length > 0) 
                    {
                        scores[j] = int.Parse(num);
                        num = "";j++;
                    }
                }
                else
                {
                    if (char.IsDigit(scorestxt[i]))
                        num += scorestxt[i];
                }
            }
                return scores;
        }
    
        static string InputScores()
        {
            StringBuilder sp=new StringBuilder();
            
            string input;
            
            while (true)
            {
               
                Console.Write($"Input score  : ");
                input = Console.ReadLine();     
                if (input==string.Empty) 
                { break;     }
                else
                {
                   // count++; 
                    sp.Append(input +','); 
                }
            }
            return sp.ToString();
        }

        static Student[] GetStudentCourse(int count)
        {
            Student[] students = new Student[count];
            for (int i = 0; i < count; i++)
            {
                Console.Write("Input Name : ");
                string name = Console.ReadLine();
                             
                string inscores = InputScores();
               
                students[i] =new Student(name,GetScoresArrFromString(inscores));

            }

            return students;
        }

        static void PrintPointArray(Point[] arr)
        {
            foreach (Point p in arr)
            {
                Console.WriteLine(p);
            }
        }


        static Point[] GetSortArray(Point[] arr)
        {
            //arr.OrderBy(p => p.X).ThenBy(p=>p.Y).ToArray();
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - 1-i; j++)
                {
                    if (arr[j].X > arr[j + 1].X || (arr[j].X == arr[j + 1].X && arr[j].Y > arr[j + 1].Y))
                    {

                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                    }

                }
            }

            return arr;
        }
        static Point[] GetNewSortArray(Point[] arr)
    {
        Point[] sortarr = new Point[arr.Length];
        
        for (int i = 0; i < arr.Length; i++)
        {
           sortarr[i] = arr[i];
        }

        for (int i = 0; i < sortarr.Length; i++)
        {
            for (int j = 0; j < sortarr.Length - 1-i; j++)
            {
                if (sortarr[j].X > sortarr[j + 1].X || (sortarr[j].X == sortarr[j + 1].X && sortarr[j].Y > sortarr[j + 1].Y))
                {
                        //Point temp = sortarr[j];
                        //sortarr[j] = sortarr[j + 1];
                        //sortarr[j + 1] = temp;
                        (sortarr[j ],sortarr[j + 1])= (sortarr[j + 1],sortarr[j]);
                }

            }
        }
        
        return sortarr;
    }
        static Point[] CreatePointRandomArray(int dimention,int rndmin,int rndmax)
        {
            Point[] pointarr = new Point[dimention];
            var random = new Random();
            for (int i = 0; i < pointarr.Length; i++)
            {
                pointarr[i] = new Point(random.Next(rndmin, rndmax), random.Next(rndmin, rndmax));
                
            }
            return pointarr;
        }
        
        static string GetStrPatern(string patrn,int repcount)
        {
            StringBuilder sp = new StringBuilder(patrn.Length * repcount);
            
                for (int i = 0; i < repcount; i++)
                {
                sp.Append(patrn);
                }
                return sp.ToString();

        }
        static string GetStringSeparator(int [] arr,char separator)
        {
            StringBuilder sb=new StringBuilder(2*arr.Length);

            for (int i = 0; i < arr.Length; i++)
            {
                sb.Append(arr[i]);
                if (i < arr.Length - 1) sb.Append(separator);
            }
            return sb.ToString();
        }

        static int [] CreateMatrix(int dimention, int rndmin,int rndmax)
        {   
            int[] arr = new int[dimention];
            Random random = new Random();
            
            for (int i = 0; i<arr.Length;i++)
            {
                arr[i]=random.Next(rndmin,rndmax);
            }
            return arr;
        }
        static void PrintMatrix(int [] arr)
        {
            foreach (int p in arr)
            {
                Console.Write(p+'\t');
            }
            Console.WriteLine();
        }
        static void PrintArray(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write($"{arr[i, j]} \t");
                }
                Console.WriteLine();
            }
        }

    }


}
