using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidatorCustom_Lib.CustomAttributes
{
    public class ContainsAttribute:ValidationAttribute
    {
        private readonly string _containstr;
        public ContainsAttribute(string containStr) 
        {
            _containstr = containStr;
            ErrorMessage = $"The {_containstr} text is not a substring :";
        }
        
        public override bool IsValid(object value)
        {
            if (value is not string str ) return false;
            
            if (string.IsNullOrWhiteSpace(str)) return false;
                        
            return str.Contains(_containstr,StringComparison.OrdinalIgnoreCase) ;
        }



    }
}
