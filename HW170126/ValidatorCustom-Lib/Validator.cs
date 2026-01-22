using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using ValidatorCustom_Lib.CustomAttributes;

namespace ValidatorCustom_Lib
{
    public sealed class Validator
    {
        public ValidationResult Validate(object target)
        {
            var result = new ValidationResult();

            Type type = target.GetType();

            foreach (var member in type.GetMembers(BindingFlags.Public | BindingFlags.Instance))
            {
                
                object value=null;

                if (member is PropertyInfo property)
                {
                    
                    value = property.GetValue(target);
                }
                else if (member is FieldInfo field)
                {
                    
                    value = field.GetValue(target);
                }
                else
                {
                    continue; 
                }

                var attributes = member.GetCustomAttributes<ValidationAttribute>();

                foreach (ValidationAttribute attribute in attributes)
                {
                    if (!attribute.IsValid(value,target))
                    {
                        var error = new ValidationError
                        {
                            MemberName = member.Name,
                            ErrorMesssage = attribute.ErrorMessage
                        };

                        result.Errors.Add(error);
                    }
                }
            }

            return result;
        }

        
    }
    


}
