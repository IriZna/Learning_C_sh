using System;
using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
using System.Text;
using ValidatorCustom_Lib.CustomAttributes;
using ValidatorCustom_Lib;
 
namespace ValidationUsageConsoleApp
{
    public enum Gender
    {
        Female,
        Male
    }
     public enum UserRole
    {
        Administrator,
        Supeviser,
        Moderator
    }

    public class User
    {
        
        [MinLengthAtttibute(3)] public string Name { get; set; }
        [AllowedValues("Admin","User","Guest","SuperUser","Moderator")] public string Role { get ; set; }

        [AllowedEnum(typeof(Gender))]  public string Gender { get; set; }

        [Contains("AM")]
        [MinLengthAtttibute(2)]
        public string CitizenCountry { get; set; }

        [Url] public string Homepage { get; set; }

              
        [Positive] [MinLengthAtttibute(2)] public int Age { get; set; }

        [AllowedEnum(typeof(UserRole))] public string UserRole { get; set; }
       

        [RequiredIf(nameof(IsInsurance), true)]   public string InsuranceCode { get; set; }
        public bool IsInsurance { get; set; }


        [FutureDate]
        public DateTime? AgreementEnd { get; set; }

        [Positive] public int Salary { get; set; }

        [Negative] public int Sale { get; set; }

        [AllowedValues("Active", "Vacation", "DayOff", "Fired")]
        public string Status { get; set; }




    }
}
