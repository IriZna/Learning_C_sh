using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidatorCustom_Lib.CustomAttributes
{
    public class AllowedValuesAttribute:ValidationAttribute
    {
        private readonly HashSet<string> _allowedValues;
        
        public AllowedValuesAttribute(params string[] allowedValues)
           
        {
            _allowedValues= new HashSet<string>(allowedValues,StringComparer.OrdinalIgnoreCase);
            
            ErrorMessage = $"Value must be one of: {string.Join(",",_allowedValues)}";
        }

        public override bool IsValid(object value)
        {
            
            if (value == null) return false;
            string stringValue = value as string ?? value.ToString();

            //return _allowedValues.Any(av =>string.Equals(av,stringValue, StringComparison.OrdinalIgnoreCase));
            return !string.IsNullOrEmpty(stringValue) && _allowedValues.Contains(stringValue);
        }

    }
}
