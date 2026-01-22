using ValidatorCustom_Lib;


namespace ValidationUsageConsoleApp
{
   
    internal class Program
    {
       
        static void Main(string[] args)
        {
            var userValid = new User
            {
                Name = "Ani",
                Age=25,
                Gender="FeMale",
                CitizenCountry = "AM",
                Role ="Admin",
                UserRole="administrator",
                Salary=1000000,
                Sale=-200,
                Status="Active",
                AgreementEnd=null,
                Homepage="http://test.am",
                InsuranceCode="Ic258",
                IsInsurance=true

            };
            var userNoValid = new User
            {
                Name = "Anahit",
                Age = 0,
                Gender = "FeeMale",
                CitizenCountry = null,
                Role = "Adminn",
                UserRole = "administra",
                Salary = -1000000,
                Sale = 200,
                Status = "Act",
                AgreementEnd = DateTime.Now,
                Homepage = "//test.am",
                //InsuranceCode = "Ic258",
                IsInsurance = true

            };
            var user3 = new User
            {
                Name = "John",
                Age = 30,
                Gender = "Male",
                CitizenCountry = "",
                Role = "User",
                UserRole = "user",
                Salary = 50000,
                Sale = 0,
                Status = "Pending",
                AgreementEnd = DateTime.Now.AddDays(30),
                Homepage = "https://example.com",
                InsuranceCode = null,
                IsInsurance = false
            };
            var user4 = new User
            {
                Name = "",    // err
                Age = 30,
                Gender = "Male",
                CitizenCountry = "US",
                Role = "User",
                UserRole = "user",
                Salary = 50000,
                Sale = 0,           // err
                Status = "DayOff",
                AgreementEnd = DateTime.Now.AddDays(30),
                Homepage = "https://examplecom", //// err
                InsuranceCode = null,  // err
                IsInsurance = false
            };

            var user5 = new User
            {
                Name = "Test",
                Age = 150, // err
                Gender = "Other",
                CitizenCountry="USA",
                Role = "Guest",
                UserRole = "guest",
                Salary = 0, // err > 0
                Sale = 0,
                Status = "Inactive",
                AgreementEnd = DateTime.Now.AddDays(-1), // err
                Homepage = "ftp://test.com", // err
                IsInsurance = true
            };

            var users = new List<User> { userValid, userNoValid,user3,user4,user5 };

            foreach (var user in users) 
            {
                Console.WriteLine($"Validating user: {user.Name}/n");
                Validation(user);

            }
    
        }
        static void Validation(object user)
                {
                    var validator = new Validator();

                    var result = validator.Validate(user);

                    if (!result.IsValid)
                    {
                        foreach (ValidationError error in result.Errors)
                        {
                            Console.WriteLine(error);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Validation successful!");
                    }
                }
    }
    

    }
