using System.Security.Cryptography.X509Certificates;

namespace HW2401_EmployeeProjects
{
    internal class Program
    {
        public class Department
        {
            public int Id { get; set; }
            public string Name { get; set; }
            
        }
        public class Employee
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int DepartmentId { get; set; }
            public decimal Salary { get; set; }
            public bool isActive { get; set; }
        }

        public class Project
        {
            public int Id { get; set; }
            public string Name { get; set; }
            //public bool isComplite {  get; set; }
        }
        public class EmployeeProject
        {
            public int EmployeeId { get; set; }
            public int ProjectId { get; set; }
            

        }

        public class DepartmentsReport
        {
            public int DepartmentId { get; set; }
            public string DepartmentName { get; set; }
            public List<string> ActiveEmployee { get; set; }
            public decimal AverageSalary {  get; set; }
            public List<TopEmployeeInfo> Top3HighSalaryEmployee { get; set; }
           // public int Rank {  get; set; }

        }
        public class TopEmployeeInfo
        {
            public string EmployeeName { get; set; }
            public decimal Salary { get; set; }

            public override string ToString()
            {
                return $"Name: {EmployeeName}, Salary: {Salary}\n";
            }
        }



        static void Main(string[] args)
        {
            var departments = new List<Department>
            {
                new Department { Id = 1,Name="HR" },
                new Department { Id = 2,Name="It" },
                new Department { Id = 3,Name="Loan" },
                new Department { Id = 4,Name="Finance" },
            };

            var employees = new List<Employee>
            {
                new Employee { Id=1,Name="Armine",DepartmentId=1,Salary=100000,isActive=true},
                new Employee { Id=2,Name="Aram",DepartmentId=1,Salary=200000,isActive=true},
                new Employee { Id=3,Name="Ani",DepartmentId=2,Salary=400000,isActive=true},
                new Employee { Id=4,Name="Karine",DepartmentId=3,Salary=150000,isActive=false},
                new Employee { Id=5,Name="Davit",DepartmentId=4,Salary=250000,isActive=true},
                new Employee { Id=6,Name="Tatev",DepartmentId=1,Salary=106000,isActive=true},
                new Employee { Id=7,Name="Arman",DepartmentId=2,Salary=450000,isActive=true},
                new Employee { Id=8,Name="ArmineP",DepartmentId=3,Salary=550000,isActive=true},
                new Employee { Id=9,Name="Areg",DepartmentId=1,Salary=210000,isActive=true},
                new Employee { Id=10,Name="Anahit",DepartmentId=2,Salary=430000,isActive=true},
                new Employee { Id=11,Name="Karine",DepartmentId=3,Salary=100000,isActive=false},
                new Employee { Id=12,Name="Artur",DepartmentId=4,Salary=1000000,isActive=true},
                new Employee { Id=13,Name="Hermine",DepartmentId=1,Salary=200000,isActive=true},
                new Employee { Id=14,Name="Hrach",DepartmentId=2,Salary=400000,isActive=false},
                new Employee { Id=15,Name="Emil",DepartmentId=2,Salary=1500000,isActive=true},
                new Employee { Id=16,Name="Edmon",DepartmentId=2,Salary=800000,isActive=false},
            };

            var projects = new List<Project>
           {
            new Project { Id = 1, Name = "Loan"},           
            new Project { Id = 2, Name = "Internet Tools"}, 
            new Project { Id = 3, Name = "HR Management"},  
            new Project { Id = 4, Name = "Payroll System"}, 
            new Project { Id = 5, Name="Bank" },            
           };

            var employeeProject = new List<EmployeeProject>
            {   
                new EmployeeProject { EmployeeId = 1, ProjectId = 3 },
                new EmployeeProject { EmployeeId = 1, ProjectId = 4 },
                new EmployeeProject { EmployeeId = 2, ProjectId = 3 },
                new EmployeeProject { EmployeeId = 3, ProjectId = 1 },
                new EmployeeProject { EmployeeId = 4, ProjectId = 1 },
                new EmployeeProject { EmployeeId = 4, ProjectId = 5 },
                new EmployeeProject { EmployeeId = 6, ProjectId = 4 },
                new EmployeeProject { EmployeeId = 6, ProjectId = 3 },
                new EmployeeProject { EmployeeId = 7, ProjectId = 5 },
                new EmployeeProject { EmployeeId = 8, ProjectId = 1 },
                new EmployeeProject { EmployeeId = 9, ProjectId = 3 },
                new EmployeeProject { EmployeeId = 10, ProjectId = 5 },
                

            };
            //average by active employees
            var reportDepart = from d in departments
                               join e in employees on d.Id equals e.DepartmentId
                               where e.isActive == true
                               join ep in employeeProject on e.Id equals ep.EmployeeId
                               join p in projects on ep.ProjectId equals p.Id
                               
                               group new { d, e } by d into g

                               let activeEmps = g.Select(x => x.e).Distinct().ToList()
                               let averageSal = activeEmps.Average(e => e.Salary)

                               orderby averageSal descending
                               select new DepartmentsReport
                               {
                                   DepartmentId = g.Key.Id,
                                   DepartmentName = g.Key.Name,
                                   ActiveEmployee = activeEmps.Select(x => x.Name).ToList(),
                                   AverageSalary = averageSal,
                                   Top3HighSalaryEmployee = activeEmps
                                                          .OrderByDescending(e => e.Salary)
                                                          .Take(3)
                                                          .Select(e => new TopEmployeeInfo
                                                          {
                                                              EmployeeName = e.Name,
                                                              Salary = e.Salary
                                                          })
                                                          .ToList()

                               };
            //average by all employees

            var reportDepart1 = from d in departments
                               let empDep = (from e in employees
                                             where d.Id == e.DepartmentId
                                             select e).ToList()
 
                               let averageSal = empDep.Average(e => e.Salary)
                               
                               orderby averageSal descending
                                
                               let activeEmp =(from ae in empDep
                                               join ep in employeeProject on ae.Id equals ep.EmployeeId
                                               join p in projects on ep.ProjectId equals p.Id
                                               where ae.isActive == true
                                               select ae
                                               ).Distinct().ToList() 
                               
                                                      
                               select new DepartmentsReport
                               {
                                   DepartmentId = d.Id,
                                   DepartmentName = d.Name,
                                   AverageSalary = averageSal,

                                   ActiveEmployee = activeEmp.Select(x => x.Name).ToList(),
                                   
                                   Top3HighSalaryEmployee = empDep.OrderByDescending(e => e.Salary)
                                                          .Take(3)
                                                          .Select(e => new TopEmployeeInfo
                                                          {
                                                              EmployeeName = e.Name,
                                                              Salary = e.Salary
                                                          })
                                                          .ToList()

                               };


            Console.WriteLine(" Analytical Report by department");
            
            int rank = 1;
            foreach (var dept in reportDepart1)
            {
                Console.WriteLine($"\nDepartment: {dept.DepartmentName}({dept.DepartmentId})  Average salary: {dept.AverageSalary:C} Rank: {rank}");
                Console.WriteLine($"Top 3: {string.Join(",", dept.Top3HighSalaryEmployee)}");

                Console.WriteLine($"Active Employees: {string.Join(",",dept.ActiveEmployee)}");
                
                  rank++;

            }



        }
    }
}
