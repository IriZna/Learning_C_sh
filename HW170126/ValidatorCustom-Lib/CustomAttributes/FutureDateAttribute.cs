using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidatorCustom_Lib.CustomAttributes
{
    public class FutureDateAttribute:ValidationAttribute
    {
        public FutureDateAttribute() 
        
        {
            ErrorMessage = "Date must be today or later";
        }
        
        
        public override bool IsValid(object value)
        {
            if (value == null) return true;

            DateTime currentDate = DateTime.UtcNow;

            if (value is DateTime dateVal)
            {
                return dateVal>currentDate;
            }

            return false;
        }
    }
}
