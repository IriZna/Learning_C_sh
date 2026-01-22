using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ValidatorCustom_Lib.CustomAttributes
{
    public class AllowedEnumAttribute:ValidationAttribute
    {   private readonly Type _enumType; 
        private readonly string[] _enumName;
        private readonly Array _enumValue;
        public AllowedEnumAttribute(Type enumType) 
        {
            _enumType = enumType;
            _enumName = Enum.GetNames(enumType);
            
            ErrorMessage = $" Value must be one of: {string.Join(",", _enumName)}";
        }
        public override bool IsValid(object value)
        {
            if (value == null) return false;

            if (value is string strValue)
            {
                return _enumName.Any(name => string.Equals(name, strValue, StringComparison.OrdinalIgnoreCase));

            }

           
            return false;
        }
    }
}
