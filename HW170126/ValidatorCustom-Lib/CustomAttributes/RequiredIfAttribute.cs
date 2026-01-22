using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ValidatorCustom_Lib.CustomAttributes
{
    public class RequiredIfAttribute:ValidationAttribute
    {
        private readonly string _dependentProperty ;
        private readonly object _expectedValue;
        public RequiredIfAttribute(string dependentProperty, object expectedValue)
        {

            _dependentProperty = dependentProperty;
             _expectedValue= expectedValue;
          
            ErrorMessage = $"The field is required when {_dependentProperty} is {expectedValue}";
        }
        
        public override bool IsValid(object value,object instance)
        {
           var instanceType=instance.GetType();
            var property = instanceType.GetProperty(_dependentProperty, BindingFlags.Public | BindingFlags.Instance);
            if (property == null)
            {
                throw new InvalidOperationException($"Property {nameof(_dependentProperty)} not found on {instanceType.Name}");
            }
            var dependentValue=property.GetValue(instance);
            if (!Equals(dependentValue, _expectedValue)) 
            {
                return true;

            }
            if (value ==null) return false;

            if (value is string str) { return !string.IsNullOrWhiteSpace(str); }
            return true;


        }
    }
}
