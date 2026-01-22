using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidatorCustom_Lib.CustomAttributes
{
    public class MinLengthAtttibute : ValidationAttribute
    {
        private readonly int _minLength;
        public MinLengthAtttibute(int minLength) 
        {
            _minLength = minLength;
            ErrorMessage = $"The field must be a string with minimum length of {_minLength} characters.";
        }

        public override bool IsValid(object value)
        {   
            if (value == null) return false;
            
            if (value is not string str) return false;
            
            if (string.IsNullOrWhiteSpace(str)) return false;
            
            return str.Length >= _minLength;
            

        }    
    
    }
}
