using Microsoft.VisualBasic;
using System.Linq.Expressions;

namespace HW2401_CliOrdersReport
{

    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Order
    {
        public int Id { get; set; } = 0;
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount {  get; set; }
        public bool IsCompleted { get; set; }

       
    }
    public class CustomerReport
    {
        public string CustomerName {  get; set; }
        public decimal TotalSpent { get; set; }
        public decimal AverageOrder { get; set; }
        public DateTime LastOrderDate { get; set; }
        public string Status { get; set; }
        public MonthlySummary  BestMonth {  get; set; }

    }
    
    public class MonthlySummary
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public decimal Total { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var customers = new Customer[]
            {
               new Customer { Id = 1,Name="Ani" },
               new Customer { Id = 2,Name="Aram" },
               new Customer { Id = 3,Name="Tatev" },
               new Customer { Id = 4,Name="Artur" },
               new Customer { Id = 5,Name="Ira" },
               new Customer { Id = 6,Name="Nobody" }
            };

            var orders = new Order[]
            {
               
                new Order { Id = 1,CustomerId=1,OrderDate=DateTime.Now,IsCompleted=false,TotalAmount=25000M},
                new Order { Id = 2,CustomerId=1,OrderDate=new DateTime(2025,5,12) ,IsCompleted=true,TotalAmount=45000.50M},
                new Order { Id = 3,CustomerId=1,OrderDate=new DateTime(2024,7,12) ,IsCompleted=true,TotalAmount=125000.7M},
                new Order { Id = 4,CustomerId=2,OrderDate=DateTime.Now ,IsCompleted=true,TotalAmount=2560M},
                new Order { Id = 5,CustomerId=2,OrderDate=DateTime.Now.AddDays(-28) ,IsCompleted=true,TotalAmount=25500M},
                new Order { Id = 6,CustomerId=3,OrderDate=new DateTime(2025,5,30) ,IsCompleted=true,TotalAmount=5000},
                new Order { Id = 7,CustomerId=3,OrderDate=DateTime.Now,IsCompleted=true,TotalAmount=22500.9M},
                new Order { Id = 8,CustomerId=4,OrderDate=new DateTime(2025,8,30)  ,IsCompleted=true,TotalAmount=23500},
                new Order { Id = 9,CustomerId=4,OrderDate=new DateTime(2024,10,30)  ,IsCompleted=true,TotalAmount=25000},
                new Order { Id = 10,CustomerId=3,OrderDate=DateTime.Now,IsCompleted=false,TotalAmount=5000},
                new Order { Id = 11,CustomerId=2,OrderDate=DateTime.Now,IsCompleted=false,TotalAmount=15740},
                new Order { Id = 12,CustomerId=4,OrderDate=DateTime.Now,IsCompleted=false,TotalAmount=25000},
                new Order { Id = 13,CustomerId=1,OrderDate=DateTime.Now.AddDays(-24),IsCompleted=true,TotalAmount=15000M},
                new Order { Id = 14,CustomerId=1,OrderDate=DateTime.Now.AddMonths(-1),IsCompleted=true,TotalAmount=35000M},
                new Order { Id = 15,CustomerId=1,OrderDate=DateTime.Now.AddDays(-29),IsCompleted=true,TotalAmount=45000M},
                new Order { Id = 16,CustomerId=2,OrderDate=DateTime.Now.AddMonths(-2),IsCompleted=true,TotalAmount=50000M},
                new Order { Id = 17,CustomerId=2,OrderDate=DateTime.Now.AddMonths(-3),IsCompleted=true,TotalAmount=60000M},
                new Order { Id = 18,CustomerId=3,OrderDate=DateTime.Now.AddMonths(-1),IsCompleted=true,TotalAmount=70000M},
                new Order { Id = 19,CustomerId=5,OrderDate=DateTime.Now.AddDays(-10),IsCompleted=true,TotalAmount=170000M}
            };

            var reportCli = (from c in customers
                            join o in orders on c.Id equals o.CustomerId
                            where o.IsCompleted == true
                            //.Where(x => x.IsCompleted == true) 
                            group o by new { c.Id,c.Name} into g

                            let cliOrders=g.ToList()
                            let totalSpent = cliOrders.Sum(o => o.TotalAmount)
                            let countOrder=cliOrders.Count
                            let averageOrder = totalSpent/countOrder
                            let lastOrderDate = cliOrders.Max(o => o.OrderDate)
                            
                            let currentdate=DateTime.Now
                            let daydiff=(currentdate-lastOrderDate).Days
                            let statCli= (daydiff<31 && countOrder==1)?"New":daydiff<90?"Active":"Lose"
                            
                            let bestmonth=(from o in cliOrders 
                                           group o by new { o.OrderDate.Year,o.OrderDate.Month} into mg
                                           
                                           let yearOrder=mg.Key.Year
                                           let monthOrder=mg.Key.Month
                                           let total=mg.Sum(o => o.TotalAmount)
                                           orderby total descending

                                           select new MonthlySummary
                                           {   Month=monthOrder,
                                               Year=yearOrder,
                                               Total=total
                                           }).FirstOrDefault()

                            select new CustomerReport
                            {
                                CustomerName = g.Key.Name,
                                TotalSpent = totalSpent,
                                AverageOrder = averageOrder,
                                LastOrderDate = lastOrderDate,
                                Status = statCli,
                                BestMonth=bestmonth                            
                              }).OrderByDescending(s=>s.TotalSpent).ThenByDescending(s=>s.LastOrderDate) ;

            Console.WriteLine("Clients Report");

            Console.WriteLine(" Analytical Report by Clients");
            

            foreach (var client in reportCli)
            {
                Console.WriteLine($"\nClient: {client.CustomerName} Status: {client.Status}");

                Console.WriteLine($"Total spent: {client.TotalSpent:C}");
                Console.WriteLine($"Last order: {client.LastOrderDate:dd.MM.yyyy}");
                Console.WriteLine($"Average summ: {client.AverageOrder:C}");

                             
                Console.WriteLine($"\nThe most profitable month: {client.BestMonth.Month} Spent: {client.BestMonth.Total}");
                
            }

            }
    }
}
